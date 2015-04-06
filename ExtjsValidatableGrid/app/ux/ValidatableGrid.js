Ext.define('ExtjsExamples.ux.ValidatableGrid', {
    grid: null,
    init: function (grid) {
        var me = this;
        me.grid = grid;
        me.grid.validate = me.validate;
    },

    validate: function () {
        var me = this, view = this.getView(), isValid = true;
        var columnLength = me.columns.length;
        me.getStore().each(function (record, idx) {
            //remove existing validation errors
            for (var j = 0; j < columnLength; j++) {
                var cell = view.getCellByPosition({row: idx, column: j});
                cell.removeCls(me.clsInvalidField);
            }
            var validationResult = record.validate();
            if (!validationResult.isValid()) {
                isValid = false;
                for (var i = 0; i < validationResult.items.length; i++) {
                    for (var jj = 0; jj < columnLength; jj++) {
                        var innerCell = view.getCellByPosition({row: idx, column: jj});
                        if (validationResult.items[i].field === me.columns[jj].dataIndex) {
                            innerCell.addCls("x-form-invalid-field");
                            innerCell.set({'data-errorqtip': validationResult.items[i].message});
                        }
                    }
                }
            }
        });
        return isValid;
    }
});