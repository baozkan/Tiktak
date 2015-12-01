define([
  // These are path alias that we configured in our bootstrap
  'jquery',     // lib/jquery/jquery
  'underscore', // lib/underscore/underscore
  'backbone',    // lib/backbone/backbone
  'collections/scopes',
], function ($, _, Backbone, ScopeCollection) {

    var ScopeListView = Backbone.View.extend({
        el: $(".panel-scopes"),
        editShown: false,
        template: _.template($('#scopes-template').html()),
        // The DOM events specific to an item.
        events: {
            "click .btn-add": "toggleContent",
            "click .btn-cancel": "toggleContent",
            "click .btn-save": "save"
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

        toggleContent: function () {
            if (this.editShown === false) {
                this.showEdit();
            } else {
                this.hideEdit();
            }
        },
        hideEdit: function () {
            this.$el.find('form.form-edit-scope').hide();
            this.$el.find('.btn-add').show();
            this.editShown = false;
        },
        showEdit: function () {
            this.$el.find('form.form-edit-scope').show();
            this.$el.find('.btn-add').hide();
            this.editShown = true;
        },
        save: function (e) {
            e.preventDefault();
            var scope = this.$el.find('form.form-edit-scope').serializeObject()
            this.collection.create(scope);
            this.hideEdit();
        }
    });
    return ScopeListView;
});