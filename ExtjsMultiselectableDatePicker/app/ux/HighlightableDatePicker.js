Ext.define('ExtjsExamples.ux.HighlightableDatePicker', {
    extend: 'Ext.picker.Date',
    selectedDates : {},
    clsHighlightClass :'x-datepicker-selected',
    initComponent:function(){
        var me = this;
        me.callParent(arguments);
        me.on('select',me.handleSelectionChanged,me);
        me.on('afterrender',me.highlightDates,me);

    },
    highlightDates: function(){
        var me = this;
        if(!me.cells)
            return;
        me.cells.each(function(item){
            var date = new Date(item.dom.firstChild.dateValue).toDateString();
            if(me.selectedDates[date]){
                if(item.getAttribute('class').indexOf(me.clsHighlightClass)=== -1){
                    item.addCls(me.clsHighlightClass);
                }
            }else{
                item.removeCls(me.clsHighlightClass);
            }
        });
    },

    handleSelectionChanged:function(cmp,date){
        var me = this;
        if(me.selectedDates[date.toDateString()])
            delete me.selectedDates[date.toDateString()];
        else
            me.selectedDates[date.toDateString()] = date;
        me.highlightDates();
    }
});