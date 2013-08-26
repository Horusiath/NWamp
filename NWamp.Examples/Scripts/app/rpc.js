(function (document, window, ko, autobahn, $) {
    'use strict';

    var CalcViewModel = function(shell) {
        var self = this;
        this.shell = shell;

        this.display = ko.observable('');
        this.fnum = ko.observable('');
        this.snum = ko.observable('');
        this.operator = ko.observable('');
        this.expression = ko.computed(function() {
            return this.fnum() + ' ' + this.operator() + ' ' + this.snum() + ' = ';
        }, this);
        this.appendDigit = function(digit) {
            var value = self.display();
            self.display(value.toString() + digit);
        };
        this.appendOperator = function(operator) {
            self.fnum(+(self.display()));
            self.operator(operator);
            self.display('');
        };

        this.clear = function() {
            self.display('');
            self.fnum('');
            self.snum('');
            self.operator('');
        };

        this.calculate = function () {
            self.snum(+(self.display()));
            var url;
            switch (self.operator()) {
                case '+': url = 'http://localhost:3333/Calculator#Add'; break;
                case '-': url = 'http://localhost:3333/Calculator#Sub'; break;
                case '*': url = 'http://localhost:3333/Calculator#Mul'; break;
                case '/': url = 'http://localhost:3333/Calculator#Div'; break;
                
                default:
                    throw Error('unknown operator: ' + self.operator());
            }

            self.shell.log('<strong>Client request:</strong> ' + url + ' <strong>with args:</strong> ' + [self.fnum(), self.snum()]);
            self.shell.session.call(url, self.fnum(), self.snum())
                .then(function (response) {
                    self.shell.log('<strong>Server response:</strong> ' + response);
                    self.display(response);
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