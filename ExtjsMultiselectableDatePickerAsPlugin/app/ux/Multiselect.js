Ext.define('ExtjsExamples.ux.Multiselect', {
    selectedDates: {},
    clsHighlightClass: 'x-datepicker-selected',
    datePicker: null,
    init: function (datePicker) {
        var me = this;
        me.datePicker = datePicker;
        // me.callParent(arguments);
        me.datePicker.on('select', me.handleSelectionChanged, me);
        me.datePicker.on('afterrender', me.highlightDates, me);

    },
    highlightDates: function () {
        var me = this;
        if (!me.datePicker.cells)
            return;
        me.datePicker.cells.each(function (item) {
            var date = new Date(item.dom.firstChild.dateValue).toDateString();
            if (me.selectedDates[date]) {
                if (item.getAttribute('class').indexOf(me.clsHighlightClass) === -1) {
                    item.addCls(me.clsHighlightClass);
                }
            } else {
                item.removeCls(me.clsHighlightClass);
            }
        });
    },

    handleSelectionChanged: function (cmp, date) {
        var me = this;
        if (me.selectedDates[date.toDateString()])
            delete me.selectedDates[date.toDateString()];
        else
            me.selectedDates[date.toDateString()] = date;
        me.highlightDates();
    }
});