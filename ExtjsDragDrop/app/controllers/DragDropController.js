Ext.define('ExtjsExamples.controllers.DragDropController', {
    extend: 'Ext.app.Controller',
    viewInstance: null,
    launch: function () {
        var me = this;
        me.viewInstance = Ext.create('ExtjsExamples.views.DragDropView');

    },

    getView: function () {
        var me = this;
        return me.viewInstance;
    }
});