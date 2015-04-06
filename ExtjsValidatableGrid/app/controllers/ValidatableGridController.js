Ext.define('ExtjsExamples.controllers.ValidatableGridController', {
    extend: 'Ext.app.Controller',
    viewInstance: null,
    launch: function () {
        var me = this;
        Ext.QuickTips.init();
        me.control({
            'button': {
                'click': {
                    scope: me,
                    fn: me.handleValidateButtonClick
                }

            }
        });

        var store = Ext.create('Ext.data.Store', {
            model:'ExtjsExamples.models.CustomerModel',
            data: [
                {id: 1, firstname: 'John'},
                {id: 2, firstname: 'Mat'},
                {id: 3, firstname: 'Kate', lastname: 'Smith'},
                {id: 4, firstname: 'Richard', lastname: 'Smith'},
                {id: 5, firstname: 'Nick'}
            ]
        });

        me.viewInstance = Ext.create('ExtjsExamples.views.ValidatableGridView', {
            store: store
        });

    },

    getView: function () {
        var me = this;
        return me.viewInstance;
    },

    handleValidateButtonClick: function () {
        var me = this;
        me.getView().vGrid.validate();
    }
});