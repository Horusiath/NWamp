(function (document, window, ko, autobahn, $) {
    'use strict';

    var CalcViewModel = function(shell) {
        var self = this;
        this.shell = shell;

        this.display = ko.observable('');
        this.appendDigit = function(digit) {
            var value = self.display();
            self.display(value.toString() + digit);
        };
        this.appendOperator = function (operator) {
            var text = self.display().toString(); 
            var nums = text.split(' ');
            if(nums.length === 1) {
                self.display(text + ' ' + operator + ' ');
            }
            else if(nums.length == 3) {
                self.calculate(operator);
            }
        };

        this.clear = function() {
            self.display('');
        };

        this.calculate = function (op) {
            var nums = self.display().toString().split(' ');
            var url;
            switch (nums[1]) {
                case '+': url = 'http://localhost:3333/Calculator#Add'; break;
                case '-': url = 'http://localhost:3333/Calculator#Sub'; break;
                case '*': url = 'http://localhost:3333/Calculator#Mul'; break;
                case '/': url = 'http://localhost:3333/Calculator#Div'; break;
                
                default:
                    throw Error('unknown operator: ' + nums[1]);
            }

            self.shell.log('<strong>Client request:</strong> ' + url + ' <strong>with args:</strong> ' + nums);
            self.shell.session.call(url, nums[0], nums[2])
                .then(function (response) {
                    self.shell.log('<strong>Server response:</strong> ' + response);
                    self.display(response);
                    if(typeof op === 'string') self.appendOperator(op);
                },
                function (error, desc) {
                    self.shell.log('<strong>Server error:</strong> ' + desc);
                    console.log(error, desc);
                });
        };
    };

    $(function () {
        var wsuri = "ws://localhost:3333";
        autobahn.connect(wsuri,
          function (session) {
              var shell = window.shell = new AppShell(session);
              shell.calculator = new CalcViewModel(shell);
              ko.applyBindings(shell);
          },
          function (code, reason) {
              console.log(reason);
          }
        );
    });
})(document, window, ko, ab, jQuery);