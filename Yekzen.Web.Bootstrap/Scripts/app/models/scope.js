define([
  'underscore',
  'backbone'
], function (_, Backbone) {
    var ScopeModel = Backbone.Model.extend({
        idAttribute: "Id"
    });

    // Return the model for the module
    return ScopeModel;
});