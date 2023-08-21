const edit = document.getElementById('edit');
const editfinish = document.getElementById('finishedit');
const myInput4 = document.getElementById('tb4');
const myInput5 = document.getElementById('tb5');

edit.addEventListener('click', function () {
    myInput4.readOnly = false;
    myInput5.readOnly = false;
    editfinish.hidden = false;
});
editfinish.addEventListener('click', function () {
    myInput4.readOnly = true;
    myInput5.readOnly = true;
    editfinish.hidden = true;
});