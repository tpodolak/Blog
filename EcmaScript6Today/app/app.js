(function () {
    var obj = {
        firstProp: 1,
        secondProp: 2
    }, array = [1, 2, 3];

    //Destructuring array
    var [x,y,z] = array;

    console.log('Destructuring array');
    console.log('Value of x = ' + x);
    console.log('Value of y = ' + y);
    console.log('Value of z = ' + z);

    console.log('Destructuring object');
    var { secondProp: b,firstProp: a } = obj;
    console.log('Value of firstProp = ' + a);
    console.log('Value of secondProp = ' + b);

}());