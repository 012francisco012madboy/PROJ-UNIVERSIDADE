const sidebar = document.querySelectorAll(".main-container .sidebar-content .side-each");

function clearActiveStates() {
    document.querySelectorAll('.side-each-child, .side-each-title, .side-each-child a').forEach(el => {
        el.classList.remove('active');
    });
}

sidebar.forEach(element => {
    const title = element.querySelector(".side-each-title");

    title.addEventListener('click', () => {
        const child = title.nextElementSibling;

        document.querySelectorAll('.side-each-child').forEach(each => {
            each.classList.remove('active');
        });

        if (child && child.classList.contains('side-each-child')) {
            child.classList.toggle('active');
        } else {
            clearActiveStates();
            title.classList.add('active');
        }
    });

    const children = element.querySelectorAll(".side-each-child a");

    children.forEach(child => {
        child.addEventListener('click', () => {
            clearActiveStates();
            child.classList.add('active');
            title.classList.add('active');
        });
    });
});