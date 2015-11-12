define([
  'jquery',
  'underscore',
  'backbone'
], function ($, _, Backbone) {

    var Scope = Backbone.Model.extend({
        idAttribute: "Id"
    });

    var Scopes = Backbone.Collection.extend({
        model : Scope,
        url: "http://localhost:19912/api/scopes",
        parse: function (data) {
            return data.Items;
        }
    });

    var ScopeView = Backbone.View.extend({
        template: _.template($('#item-template').html()),
        render: function () {
            this.el = this.template(this.model.toJSON());
            return this;
        }
    });

    var AppView = Backbone.View.extend({
        // el - stands for element. Every view has a element associate in with HTML
        //      content will be rendered.
        el: '.list-scope',
        // template which has the placeholder 'who' to be substitute later
        template: _.template($('#item-template').html()),

        // It's the first function called when this view it's instantiated.
        initialize: function () {
            var self = this;
            self.collection = new Scopes();
            
            // This uses jQuery's Deferred functionality to bind render() to the model's 
            // fetch promise, which is called after the AJAX request completes
            self.collection.fetch().done(function () {
                self.listenTo(self.collection, 'change', this.render);
                self.render();
            });
        },

        render: function () {
            var self = this;
            _.each(this.collection.models, function (item) {
                self.renderScope(item);
            }, this);
        },

        // $el - it's a cached jQuery object (el), in which you can use jQuery functions
        //       to push content. Like the Hello World in this case.
        renderScope: function (data) {
            // render the function using substituting the varible 'who' for 'world!'.
            var view = new ScopeView({
                model: data
            });
            view.render();
            this.$el.append(view.el);
        }
    });

    return AppView;
});


