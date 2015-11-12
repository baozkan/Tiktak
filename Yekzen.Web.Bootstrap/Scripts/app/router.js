// Filename: router.js
define([
  'jquery',
  'underscore',
  'backbone',
  'appView'
], function ($, _, Backbone, AppView) {

    var AppRouter = Backbone.Router.extend({
        routes: {
            // Default
            '*actions': 'defaultAction'
        }
    });

    var initialize = function () {

        var app_router = new AppRouter;

        app_router.on('route:defaultAction', function (actions) {
            // We have no matching route, lets display the home page  
            var view = new AppView();
        });

        Backbone.history.start();
    };
    return {
        initialize: initialize
    };
});