Ext.define('ExtjsExamples.views.DragDropView', {
    extend:'Ext.container.Container',
    renderTpl:Ext.create('Ext.Template',
        '<div id="table_container">',
        '<table id="leftTable" style="margin: 20px 20px">',
        '<tr>',
        '<th>a</th>',
        '<th>b</th>',
        '</tr>',
        '<tr>',
        '<td>1</td>',
        '<td>2</td>',
        '</tr>',
        '<tr>',
        '<td>4</td>',
        '<td>9</td>',
        '</tr>',
        '<tr>',
        '<td>16</td>',
        '<td>25</td>',
        '</tr>',
        '</table>',
        '<table id="rightTable" style="margin: 20px 20px">',
        '<tr>',
        '<th>a</th>',
        '<th>b</th>',
        '</tr>',
        '<tr>',
        '<td>1</td>',
        '<td>2</td>',
        '</tr>',
        '<tr>',
        '<td>4</td>',
        '<td>9</td>',
        '</tr>',
        '<tr>',
        '<td>16</td>',
        '<td>25</td>',
        '</tr>',
        '</table>',
        '</div>'),

    initComponent:function () {
        var me = this;
        me.callParent(arguments);
        me.on('afterrender', me.createDragDropZones, me);
    },

    createDragDropZones:function () {
        var me = this,
            rightTable = me.el.select('#rightTable').first(),
            leftTable = me.el.select('#leftTable').first();
        Ext.create('Ext.dd.DragZone', rightTable, {
            getDragData:function (e) {
                if (e.target.nodeName === 'TD') {
                    var sourceEl = e.target;
                    var d = sourceEl.cloneNode(true);
                    d.id = Ext.id();
                    return {
                        ddel:d,
                        sourceEl:sourceEl,
                        repairXY:Ext.fly(sourceEl).getXY()
                    };
                }
            },
            getRepairXY:function () {
                return this.dragData.repairXY;
            }
        });

        Ext.create('Ext.dd.DropZone', leftTable, {
            getTargetFromEvent:function (e) {
                if (e.target.nodeName === 'TD')
                    return e.target;
            },
            onNodeEnter:function (target) {
                Ext.fly(target).addCls('drop-target-hover');
            },
            onNodeOut:function (target) {
                Ext.fly(target).removeCls('drop-target-hover');
            },
            onNodeOver:function () {
                return Ext.dd.DropZone.prototype.dropAllowed;
            },
            onNodeDrop:function (target, dd) {
                target.parentNode.replaceChild(dd.dragData.ddel, target);
                return true;
            }
        });
    }
});