Ext.define('ExtjsExamples.controllers.DropDownController', {
    extend: 'Ext.app.Controller',
    viewInstance: null,
    launch: function () {
        var me = this;

        var states = Ext.create('Ext.data.Store', {
            fields: ['id', 'abbr', 'name'],
            data: [
                {id: 1, abbr: "AL", name: "Alabama"},
                {id: 2, abbr: "AK", name: "Alaska"},
                {id: 3, abbr: "AZ", name: "Arizona"},
                {id: 4, abbr: "AZ", name: "Arizona"},
                {id: 5, abbr: "AZ", name: "Arizona"}
            ]
        });


        me.viewInstance = Ext.create('ExtjsExamples.views.DropDownView', {
            states: states
        });

    },

    getView: function() {
        var me = this;
        return me.viewInstance;
    }
});