Ext.define('ExtjsExamples.views.DropDownView', {
    extend: 'Ext.container.Container',
    initComponent: function () {

        var me = this;
        me.callParent(arguments);
        var combo = Ext.create('Ext.form.ComboBox', {
            fieldLabel: 'Choose State',
            store: me.states,
            queryMode: 'local',
            valueField: 'abbr',
            displayField: 'name',
            renderTo: Ext.getBody(),
            tpl: Ext.create('Ext.XTemplate',
                '<tpl for=".">',
                '<div class="{[this.getClass(values)]}">{abbr} - {name}</div>',
                '</tpl>',
                {
                    getClass: function (rec) {
                        return rec.name === 'Arizona' ? 'x-boundlist-item x-highlighted-item' : 'x-boundlist-item';
                    }
                }
            )
        });

        me.add(combo);
    }
});