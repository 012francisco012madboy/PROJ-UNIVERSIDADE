const sidebar = document.querySelectorAll(".main-container .sidebar-content .side-each");

sidebar.forEach(element => {
    const title = element.querySelector(".side-each-title");

    title.addEventListener('click', () => {
        const child = title.nextElementSibling;

        document.querySelectorAll('.side-each-child').forEach(each => {
            each.classList.remove('active');
        });

        if (child && child.classList.contains('side-each-child')) {
            child.classList.toggle('active');
        }
    });
});