define([
  // These are path alias that we configured in our bootstrap
  'jquery',     // lib/jquery/jquery
  'underscore', // lib/underscore/underscore
  'backbone',    // lib/backbone/backbone
], function ($, _, Backbone) {

    var ScopeView = Backbone.View.extend({
        //... is a list tag.
        tagName: "il",

        // Cache the template function for a single item.
        template: _.template($('#item-template').html()),

        // The DOM events specific to an item.
        events: {
            "dblclick div.todo-content": "edit",
            "click span.todo-destroy": "clear",
            "keypress .todo-input": "updateOnEnter"
        },

        // The ScopeView listens for changes to its model, re-rendering. 
        initialize: function () {
            _.bindAll(this, 'render', 'close');
            this.model.bind('change', this.render);
            this.model.view = this;
        },

        // Re-render the contents of the todo item.
        render: function () {
            $(this.el).html(this.template(this.model.toJSON()));
            this.setContent();
            return this;
        },

        // To avoid XSS (not that it would be harmful in this particular app),
        // use `jQuery.text` to set the contents of the scope item.
        setContent: function () {
            var content = this.model.get('content');
            this.$('.todo-content').text(content);
            this.input = this.$('.todo-input');
            this.input.bind('blur', this.close);
            this.input.val(content);
        },

        // Switch this view into `"editing"` mode, displaying the input field.
        edit: function () {
            $(this.el).addClass("editing");
            this.input.focus();
        },

        // Close the `"editing"` mode, saving changes to the todo.
        close: function () {
            this.model.save({ content: this.input.val() });
            $(this.el).removeClass("editing");
        },

        // If you hit `enter`, we're through editing the item.
        updateOnEnter: function (e) {
            if (e.keyCode == 13) this.close();
        },

        // Remove this view from the DOM.
        remove: function () {
            $(this.el).remove();
        },
    });

    // Above we have passed in jQuery, Underscore and Backbone
    // They will not be accessible in the global scope
    return ScopeView;
    // What we return here will be used by other modules
});
