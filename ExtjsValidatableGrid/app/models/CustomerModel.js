Ext.define('ExtjsExamples.models.CustomerModel', {
    extend: 'Ext.data.Model',
    fields: [
        {name: 'id', type: 'int'},
        {name: 'lastname', type: 'string'},
        {name: 'firstname', type: 'string'}
    ],
    validations: [{type: 'presence', field: 'lastname', message: 'Required field'}]
});