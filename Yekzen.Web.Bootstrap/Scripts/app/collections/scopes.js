// Filename: collections/projects
define([
  'underscore',
  'backbone',
  // Pull in the Model module from above
  'models/scope'
], function (_, Backbone, ScopeModel) {

    var ScopeCollection = Backbone.Collection.extend({
        model: ScopeModel,
        url: "http://localhost:19912/api/scopes",
        parse: function (data) {
            return data.Items;
        }
    });

    // You don't usually return a collection instantiated
    return ScopeCollection;
});