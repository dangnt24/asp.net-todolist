const showHideToggle = () => {
    var menuToggle = document.getElementById("navbar__menu--show");
    var lnavbar = document.getElementById("l-navbar");
    var navbarClose = document.getElementById("navbar__menu--close");
    var taskOptionClose = document.getElementById("task__options--close");
    var taskOption = document.getElementById("task__options");
    var listOptionBtn = document.getElementById("list__addList--btn");
    var listOption = document.getElementById("list__addList");

    menuToggle.addEventListener("click", () => {
        lnavbar.classList.toggle("show");
        menuToggle.classList.toggle("show");
    });

    navbarClose.addEventListener("click", () => {
        lnavbar.classList.toggle("show");
        menuToggle.classList.toggle("show");
    });

    if (taskOption && taskOptionClose) {
        taskOptionClose.onclick = () => {
            taskOption.classList.remove("show");
        }
    }

    if (listOption && listOptionBtn) {
        listOptionBtn.onclick = () => {
            listOption.classList.toggle("show");
        }
    }
}

const selectColor = (listColors, colorRender, listColorData) => {
    var listColors = document.querySelectorAll(listColors);
    var colorRender = document.getElementById(colorRender);
    var listColorData = document.getElementById(listColorData);

    listColors.forEach(item => {
        item.onclick = (e) => {
            colorRender.style.backgroundColor = e.target.dataset.listColor;
            listColorData.value = e.target.dataset.listColor;
        }
    });
}

const finished = (ckElement) => {
    var ckElements = document.querySelectorAll(ckElement);
    if (ckElement) {
        ckElements.forEach(item => {
            item.onclick = (e) => {
                e.target.parentElement.parentElement.classList.toggle("checked");
                e.stopPropagation();
            }
        });
    }
}

var renderImages = (task) => {
    var fullPage = document.querySelector('#fullpage');
    var taskImageUpdate = document.getElementById("task__image--update");
    var TaskImage = document.getElementById("TaskImage");
    var html;

    if (task.dataset.image) {
        var arrImage = task.dataset.image.split("--dvp--");

        html = "";
        arrImage.forEach(image => {
            html += `
                <div class="col-12 mb-2 position-relative">
                    <img class="img-fluid task__image w-100" src="/Images/${image}" alt="image" style="min-height: 200px;" />
                    <img class="position-absolute task__image--del" data-image="${image}" src="/Images/xmark.png" style="width: 20px; height: 20px; top: 1%; right: 5%; cursor: pointer;" />
                </div>
            `;
        });

        TaskImage.innerHTML = html;

        var imgs = document.querySelectorAll('.task__image');
        var imgDelBtns = document.querySelectorAll('.task__image--del');

        imgs.forEach(img => {
            img.addEventListener('click', function (e) {
                fullPage.style.backgroundImage = 'url(' + e.target.src + ')';
                fullPage.style.display = 'block';
            });
        });

        var taskImgs = [];
        imgDelBtns.forEach(btn => {
            taskImgs.push(btn.dataset.image);
            btn.onclick = (e) => {
                var isDel = confirm("Are you sure you can delete this photo?");

                if (isDel) {
                    e.target.parentElement.remove();
                    var index = taskImgs.indexOf(e.target.dataset.image);
                    if (index > -1) taskImgs.splice(index, 1);
                    taskImageUpdate.value = taskImgs.join("--dvp--");
                    task.dataset.image = taskImgs.join("--dvp--");

                    renderImages(task);
                }
            }
        });
    } else {
        TaskImage.innerHTML = "";
    }
}

const showTaskOptions = () => {
    var tasks = document.querySelectorAll(".task__item");
    var taskOptions = document.getElementById("task__options");
    var TaskID = document.getElementById("TaskID");
    var TaskTitle = document.getElementById("TaskTitle");
    var TaskDescription = document.getElementById("TaskDescription");
    var ListID = document.getElementById("ListID");
    var DueDate = document.getElementById("DueDate");
    var TaskImage = document.getElementById("TaskImage");
    var taskImageUpdate = document.getElementById("task__image--update");
    var TaskDelBtn = document.getElementById("TaskDelBtn");


    tasks.forEach(task => {
        task.onclick = (e) => {
            var taskElement = e.target;
            if (e.target && !e.target.classList.contains("task__item")) {
                taskElement = e.target.parentElement;
                if (!taskElement.classList.contains("task__item")) taskElement = taskElement.parentElement;
            }
                taskOptions.classList.remove("show");
                taskOptions.classList.add("show");
                TaskID.value = taskElement.dataset.id;
                TaskTitle.value = taskElement.dataset.title ? taskElement.dataset.title : "";
                TaskDescription.value = taskElement.dataset.description ? taskElement.dataset.description : "";
                ListID.value = taskElement.dataset.listid;

                if (taskElement.dataset.duedate) {
                    var d = new Date(taskElement.dataset.duedate);
                    month = '' + (d.getMonth() + 1);
                    day = '' + d.getDate();
                    year = d.getFullYear();

                    if (month.length < 2)
                        month = '0' + month;
                    if (day.length < 2)
                        day = '0' + day;

                    if (day && month && year) DueDate.value = [year, month, day].join('-');
                } else {
                    DueDate.value = "";
                }

                TaskDelBtn.href = "/Task/DeleteTask?isHome=" + taskElement.dataset.isHome + "&id=" + taskElement.dataset.id;
                taskImageUpdate.value = taskElement.dataset.image;
                renderImages(taskElement);
        }
    });
}

const stickyWallAction = () => {
    var swLists = document.getElementById("sw__lists");
    var addBtn = document.getElementById("sw__add--btn");
    var changeColorBtn = document.querySelectorAll(".sw__changeColor--btn");

    if (swLists) {
        changeColorBtn.forEach(btn => {
            btn.onclick = (e) => {
                e.target.parentElement.classList.toggle("show");
            }
        });

        addBtn.onclick = () => {
            var swItem = document.createElement("div");
            var swItems = Array.from(document.querySelectorAll(".sw__item"));
            var bgColors = ["#fdf2b3", "#d1eaed", "#ffdada", "#ffd4a9", "#bcfdb3", "#ffa4d8"];

            var bgColor;
            if (swItems.length > 0) {
                do {
                    bgColor = bgColors[Math.floor(Math.random() * bgColors.length)];
                }
                while (bgColor == swItems.pop().style.backgroundColor);
            } else {
                bgColor = "#fdf2b3";
            }

            swItem.classList.add("col-lg-4", "col-md-6", "col-12", "ps-0", "pe-3");
            swItem.style.cursor = "pointer";

            var html = `
                <div class="mb-4 rounded sw__item" style="width: 100%; max-width: 320px; height: 300px; background-color: ${bgColor};">
                    <form method="post" action="/StickyWall/Add">
                        <input type="hidden" name="BgColor" class="BgColor" value="${bgColor}" />

                        <div class="p-3 pb-5 position-relative sw__item--content">
                            <input name="SwTitle" type="text" class="fw-bold" style="width:98%; color: #333; font-size: 18px; border: 0; background-color: transparent;" value="" placeholder="Title" required>
                            <textarea name="SwDescription" rows="10" class="w-100 h-100" style="color: #444; border: 0; background-color: transparent;" placeholder="Description"></textarea>
                            <button type="submit" class="position-absolute" style="top: 0.6rem; right: 0.6rem; font-size: 24px; box-shadow: none; border: 0; padding: 0; background: none;"><i class="fas fa-check fw-bold"></i></button>
                            <button type="submit" class="position-absolute sw__cancel--btn" style="top: 2.5rem; right: 0.9rem; font-size: 24px; box-shadow: none; border: 0; padding: 0; background: none;"><i class="fas fa-times fw-bold"></i></button>
                            <img class="position-absolute sw__changeColor--btn" style="width: 22px; height: 22px; top: 4.6rem; right: 0.7rem;" src="/Images/icon-change-color.jpg" alt="changeColor" />
                            <div style="display: none;" class="sw__changeColor">
                                <a class="position-absolute rounded sw__color" data-color="#fdf2b3" style="top: 6.6rem; right: 0.5rem; width: 20px; height: 20px; background-color: #fdf2b3; border: 1px solid #333;"></a>
                                <a class="position-absolute rounded sw__color" data-color="#d1eaed" style="top: 8.6rem; right: 0.5rem; width: 20px; height: 20px; background-color: #d1eaed; border: 1px solid #333;"></a>
                                <a class="position-absolute rounded sw__color" data-color="#ffdada" style="top: 10.6rem; right: 0.5rem; width: 20px; height: 20px; background-color: #ffdada; border: 1px solid #333;"></a>
                                <a class="position-absolute rounded sw__color" data-color="#ffd4a9" style="top: 12.6rem; right: 0.5rem; width: 20px; height: 20px; background-color: #ffd4a9; border: 1px solid #333;"></a>
                                <a class="position-absolute rounded sw__color" data-color="#bcfdb3" style="top: 14.6rem; right: 0.5rem; width: 20px; height: 20px; background-color: #bcfdb3; border: 1px solid #333;"></a>
                                <a class="position-absolute rounded sw__color" data-color="#ffa4d8" style="top: 16.6rem; right: 0.5rem; width: 20px; height: 20px; background-color: #ffa4d8; border: 1px solid #333;"></a>
                            </div>
                        </div>
                    </form>
                </div>
            `;

            swItem.innerHTML = html;

            swItem.querySelector(".sw__changeColor--btn").onclick = () => {
                swItem.querySelector(".sw__item--content").classList.toggle("show");
            };

            swItem.querySelectorAll(".sw__color").forEach(item => {
                item.onclick = (e) => {
                    swItem.querySelector(".sw__item").style.backgroundColor = e.target.dataset.color;
                    swItem.querySelector(".BgColor").value = e.target.dataset.color;
                }
            });

            swItem.querySelector(".sw__cancel--btn").onclick = () => {
                swItem.remove();
            }

            swItem.querySelector("input[name='SwTitle']").focus();
            addBtn.remove();
            swLists.appendChild(swItem);

            var newAddBtn = document.createElement("div");
            newAddBtn.setAttribute("id", "sw__add--btn");
            newAddBtn.classList.add("col-lg-4", "col-md-6", "col-12", "ps-0", "pe-3");
            newAddBtn.style.cursor = "pointer";
            newAddBtn.innerHTML = `
                <div class="mb-4 rounded d-flex justify-content-center align-items-center" style="width: 100%; max-width: 320px; height: 300px; background-color: #ddd;">
                    <div class="p-3 pb-5 text-dark rounded">
                        <i class="fas fa-plus p-sm-5 text-dark"; font-size: 60px;"></i>
                    </div>
                </div>
            `;
            swLists.appendChild(newAddBtn);

            stickyWallAction();
        }
    }
}

showHideToggle();
selectColor(".list__color--select", "list__color--render", "ListColor");
finished(".task__item--ck");
finished(".subtask__item--ck");
showTaskOptions();
stickyWallAction();