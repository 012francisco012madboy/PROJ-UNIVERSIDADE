const sidebar = document.querySelector(".main-container .sidebar-content");
const navButton = document.querySelector(".nav-container .nav-each .nav-button");

navButton.addEventListener('click', () => {
    const icon = navButton.querySelector("i");

    if (icon.classList.contains("fa-arrow-left-long")) {
        icon.classList.remove("fa-arrow-left-long")
        icon.classList.add("fa-arrow-right-long")
        sidebar.classList.remove("show")
    }
    else {
        icon.classList.remove("fa-arrow-right-long")
        icon.classList.add("fa-arrow-left-long")
        sidebar.classList.add("show")
    }
});


const eachSidebar = document.querySelectorAll(".main-container .sidebar-content .side-each");

eachSidebar.forEach(element => {
    const title = element.querySelector(".side-each-title");

    title.addEventListener('mouseenter', () => {
        const child = title.nextElementSibling;

        document.querySelectorAll('.side-each-child').forEach(each => {
            each.classList.remove('active');
        });

        if (child && child.classList.contains('side-each-child')) {
            child.classList.add('active');
        }
    });
});