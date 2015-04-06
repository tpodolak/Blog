Ext.define('ExtjsExamples.controllers.MultiselectableDatePickerController', {
    extend: 'Ext.app.Controller',
    viewInstance: null,
    launch: function () {
        var me = this;
        me.viewInstance = Ext.create('ExtjsExamples.views.MultiselectableDatePickerView');
    },

    getView: function() {
        var me = this;
        return me.viewInstance;
    }
});