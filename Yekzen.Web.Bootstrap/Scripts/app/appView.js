define([
  'jquery',
  'underscore',
  'backbone'
], function ($, _, Backbone) {

    var AppView = Backbone.View.extend({
        // el - stands for element. Every view has a element associate in with HTML
        //      content will be rendered.
        el: '.app-main',
        events: {
            'click button': 'show'
        },
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
        },
        show: function () {
            alert('Hello world!');
        }
    });

    return AppView;
});


