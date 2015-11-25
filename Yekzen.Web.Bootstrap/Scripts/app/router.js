// Filename: router.js
define([
  'jquery',
  'underscore',
  'backbone',
  'views/scope/list',
], function ($, _, Backbone, ScopeListView) {

    var AppRouter = Backbone.Router.extend({
        routes: {
            'scopes': 'showScopes',

            // Default
            '*actions': 'defaultAction'
        }
    });

    var initialize = function () {

        var app_router = new AppRouter;

        app_router.on('route:showScopes', function () {
            // Call render on the module we loaded in via the dependency array
            // 'views/scope/list'
            var scopeListView = new ScopeListView();
            scopeListView.render();
        });

        app_router.on('route:defaultAction', function (actions) {
            // We have no matching route, lets just log what the URL was
            console.log('No route:', actions);
        });

        Backbone.history.start();
    };
    return {
        initialize: initialize
    };
});