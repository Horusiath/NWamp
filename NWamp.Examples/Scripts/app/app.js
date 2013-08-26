(function(document, window, $, ko, autobahn) {
    'use strict';

    window.AppShell = function(session) {
        var self = this;
        this.session = session;
        this.logs = ko.observableArray([]);

        this.log = function(e) {
            self.logs.push({ msg: e });
        };
        
        this.connected = ko.computed(function() {
            return this.session != undefined;
        }, this);
    };

})(document, window, jQuery, ko, ab);