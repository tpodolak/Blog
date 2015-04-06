Ext.onReady(function () {
    Ext.Loader.setConfig({
        enabled: true
    });
    Ext.application({
        name: 'ExtjsExamples',
        appFolder: 'app',
        launch: function () {
            var me = this;
            me.viewPort = Ext.create('ExtjsExamples.views.ExtendedViewPort', {
                application: me
            });
        }
    });

});