const sidebar = document.querySelectorAll(".main-container .sidebar-content .side-each")

sidebar.forEach(element => {
    const title = element.querySelector(".side-each-title")

    title.addEventListener('click', () => {
        document.querySelectorAll('.side-each-child').forEach(each => {
            each.classList.remove('active');
        });

        const child = title.nextElementSibling;

        if (child && child.classList.contains('side-each-child')) {
            child.classList.toggle('active');
        }
        else {
            document.querySelectorAll('.side-each-title').forEach(each => {
                each.classList.remove('active');
            });

            title.classList.add('active');
        }
    });

    const child = element.querySelector(".side-each-child")

    if (child) {
        child.addEventListener('click', () => {
            document.querySelectorAll('.side-each-child').forEach(each => {
                each.classList.remove('active');
            });

            document.querySelectorAll('.side-each-title').forEach(each => {
                each.classList.remove('active');
            });

            title.classList.add('active');
        })
    }
});