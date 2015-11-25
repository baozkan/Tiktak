define([
  // These are path alias that we configured in our bootstrap
  'jquery',     // lib/jquery/jquery
  'underscore', // lib/underscore/underscore
  'backbone',    // lib/backbone/backbone
  'collections/scopes',
], function ($, _, Backbone,ScopeCollection) {
    
    var ScopeListView = Backbone.View.extend({
        el: $(".panel-scopes ul.list-group"),
        template: _.template($('#scopes-template').html()),
        // The DOM events specific to an item.
        events: {
            "click .btn-edit": "select",
        },
        initialize: function () {
            this.collection = new ScopeCollection();
            this.listenTo(this.collection, 'reset add change remove', this.render, this);
            this.collection.fetch({ data: { fetch: true, type: "post", page: 1 } });
        },

        render: function () {
            var data = {
                scopes: this.collection.models,
                _: _
            };
            
            this.$el.html(this.template(data));
        },

        select: function () {
            alert('ok');
        }
});
return ScopeListView;
});