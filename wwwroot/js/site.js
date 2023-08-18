const edit = document.getElementById('edit');
const editfinish = document.getElementById('finishedit');
const myInput1 = document.getElementById('tb1');
const myInput2 = document.getElementById('tb2');
const myInput3 = document.getElementById('tb3');
const myInput4 = document.getElementById('tb4');
const myInput5 = document.getElementById('tb5');
const myInput6 = document.getElementById('bd');

edit.addEventListener('click', function () {
    myInput1.readOnly = false;
    myInput2.readOnly = false;
    myInput3.readOnly = false;
    myInput4.readOnly = false;
    myInput5.readOnly = false;
    myInput6.readOnly = false;
    editfinish.hidden = false;
});
editfinish.addEventListener('click', function () {
    myInput1.readOnly = true;
    myInput2.readOnly = true;
    myInput3.readOnly = true;
    myInput4.readOnly = true;
    myInput5.readOnly = true;
    myInput6.readOnly = true;
    editfinish.hidden = true;
});