Ext.define('ExtjsExamples.controllers.VerticalHeaderController', {
    extend: 'Ext.app.Controller',
    viewInstance: null,
    launch: function () {
        var me = this;

        var store = Ext.create('Ext.data.Store', {
            fields: ['id', 'firstname', 'lastname'],
            data: [
                {  id: 1, firstname: 'John'},
                {  id: 2, firstname: 'Mat'},
                {  id: 3, firstname: 'Kate',lastname:  'Smith'},
                {  id: 4, firstname: 'Richard',lastname:  'Smith'},
                {  id: 5, firstname: 'Nick'}
            ]
        });

        me.viewInstance = Ext.create('ExtjsExamples.views.VerticalHeaderView', {
            store: store
        });

    },

    getView: function() {
        var me = this;
        return me.viewInstance;
    }
});