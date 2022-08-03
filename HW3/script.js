const taskText = document.getElementById('task-text');
const addButton = document.getElementById('add-button');
const uncompletedTask = document.getElementById('uncompleted-task');
const completedTask = document.getElementById('completed-task');
let taskList = [];

if (localStorage.getItem('taskList')) {
    taskList = JSON.parse(localStorage.getItem('taskList'));
    updateAllTaskDisplay();
} else {
    uncompletedTask.innerHTML = '<h3>Press \'ADD\' to add task</h3>';
}

function saveToLocalStorage(name, arr) {
    if (arr.length == 0) {
        localStorage.removeItem(name);
        return;
    }

    localStorage.setItem(name, JSON.stringify(arr));
}

function updateAllTaskDisplay() {
    updateUncompletedTaskDisplay();
    updateCompletedTaskDisplay();
}

function toggleAllButtonAndCheckbox() {
    document.querySelectorAll(`button`).forEach((button) => {
        button.disabled = !button.disabled;
        button.classList.toggle('disabled');
    });
    document.querySelectorAll(`input[type='checkbox']`).forEach((checkbox) => {
        checkbox.disabled = !checkbox.disabled;
        checkbox.classList.toggle('disabled');
    });
    document.querySelectorAll(`label`).forEach((label) => {
        label.classList.toggle('disabled');
    });
}

function changeTaskCheckboxEventHandler(index) {
    taskList[index].checked = !taskList[index].checked; 
    saveToLocalStorage('taskList', taskList);
    updateAllTaskDisplay();
}

function clickEditButtonEventHandler(index) {
    toggleAllButtonAndCheckbox();
    document.getElementById(`block-${index}`).innerHTML = `
    <input id='new-task-text-${index}' class='input-area' type='text' placeholder='Enter task text (maximum 256 characters)' value='${taskList[index].text}'>
    <button class='neutral-button' onclick='clickSaveButtonEventHandler(${index})' id='save-button-${index}'>SAVE</button>
    <button class='warn-button' onclick='clickCancelButtonEventHandler(${index})' id='cancel-button-${index}'>CANCEL</button>
    `;
}

function clickSaveButtonEventHandler(index) {
    if (document.getElementById(`new-task-text-${index}`).value.trim().length == 0) {
        alert('First enter the text of the task');
        return;
    }

    toggleAllButtonAndCheckbox();
    taskList[index].text = document.getElementById(`new-task-text-${index}`).value.trim();
    saveToLocalStorage('taskList', taskList);
    if (!taskList[index].checked) {
        updateUncompletedTaskDisplay();
    } else {
        updateCompletedTaskDisplay();
    }
}

function clickCancelButtonEventHandler(index) {
    toggleAllButtonAndCheckbox();
    document.getElementById(`block-${index}`).innerHTML = `
    <input type='checkbox' onchange='changeTaskCheckboxEventHandler(${index})' id='task-${index}' ${taskList[index].checked ? 'checked' : ''}>
    <label for='task-${index}'>${taskList[index].text}</label>
    <button class='neutral-button' onclick='clickEditButtonEventHandler(${index})' id='edit-button-${index}'>EDIT</button>
    <button class='warn-button' onclick='clickDeleteButtonEventHandler(${index})' id='delete-button-${index}'>DELETE</button>
    `;
}

function clickDeleteButtonEventHandler(index) {
    if (taskList[index].checked == false) {
        if (confirm('Are you sure you want to delete this task?')) {
            taskList.splice(index, 1);
            saveToLocalStorage('taskList', taskList);
            updateAllTaskDisplay();
        }

        return;
    }

    taskList.splice(index, 1);
    saveToLocalStorage('taskList', taskList);
    updateAllTaskDisplay();
}

addButton.addEventListener('click', () => {
    if (taskText.value.trim().length == 0) {
        alert('First enter the text of the task');
        return;
    }

    taskList.push( { text: taskText.value.trim(), checked: false } );
    taskText.value = '';
    saveToLocalStorage('taskList', taskList);
    updateUncompletedTaskDisplay();
});

function updateUncompletedTaskDisplay() {
    if (!taskList.some((task) => task.checked == false)) {
        uncompletedTask.innerHTML = '<h3>Press \'ADD\' to add task</h3>';
        return;
    }

    uncompletedTask.innerHTML = `<div class='separator'>${taskList.filter((task) => task.checked == false).length} TASKS<div>`; 
    taskList.forEach((task, index) => {
        if (!task.checked) {
            uncompletedTask.innerHTML += `
            <div id='block-${index}' class='task flex'>
                <div>
                    <input type='checkbox' onchange='changeTaskCheckboxEventHandler(${index})' id='task-${index}' ${task.checked ? 'checked' : ''}>
                </div>
                <div class='task-text'>
                    <label for='task-${index}'>${task.text}</label>
                </div>
                <button class='neutral-button' onclick='clickEditButtonEventHandler(${index})' id='edit-button-${index}'>EDIT</button>
                <button class='warn-button' onclick='clickDeleteButtonEventHandler(${index})' id='delete-button-${index}'>DELETE</button>
            </div>
            `;
        }  
    });
}

function updateCompletedTaskDisplay() {
    if (!taskList.some((task) => task.checked == true)) {
        completedTask.innerHTML = '';
        return;
    }

    completedTask.innerHTML = '<div class=\'separator\'>COMPLETED<div>'; 
    taskList.forEach((task, index) => {
        if (task.checked) {
            completedTask.innerHTML += `
            <div id='block-${index}' class='task flex'>
                <div>
                    <input type='checkbox' onchange='changeTaskCheckboxEventHandler(${index})' id='task-${index}' ${task.checked ? 'checked' : ''}>
                </div>
                <div class='task-text'>
                    <label for='task-${index}'>${task.text}</label>
                </div>
                <button class='neutral-button' onclick='clickEditButtonEventHandler(${index})' id='edit-button-${index}'>EDIT</button>
                <button class='warn-button' onclick='clickDeleteButtonEventHandler(${index})' id='delete-button-${index}'>DELETE</button>
            </div>
            `;
        }
    });
}