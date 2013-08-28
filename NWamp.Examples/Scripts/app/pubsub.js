(function(document, window, ko, $, autobahn) {
    'use strict';

    var PubSubViewModel = function(shell) {
        var self = this;
        this.shell = shell;
        this.users = ko.observableArray([]);
        this.username = ko.observable('');

        this.currentMessage = ko.observable('');

        this.send = function() {

        };

        this.join = function() {

        };

        this.leave = function() {

        };
    };
    

    $(function () {
        var wsuri = "ws://localhost:3333";
        autobahn.connect(wsuri,
          function (session) {
              var shell = window.shell = new AppShell(session);
              shell.calculator = new PubSubViewModel(shell);
              ko.applyBindings(shell);
          },
          function (code, reason) {
              console.log(reason);
          }
        );
    });
})(document, window, ko, jQuery, ab);