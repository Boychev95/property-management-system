document.addEventListener("DOMContentLoaded", () => {

    const sidebar = document.getElementById("sidebar");
    const toggleSidebar = document.getElementById("toggleSidebar");
    const themeToggle = document.getElementById("themeToggle");
    const userBlock = document.getElementById("userBlock");
    const userDropdown = document.getElementById("userDropdown");

    /* RESTORE SIDEBAR STATE */
    if (localStorage.getItem("sidebar") === "compact") {
        sidebar.classList.add("compact");
    }

    /* RESTORE THEME */
    if (localStorage.getItem("theme") === "dark") {
        document.body.classList.remove("light-theme");
        document.body.classList.add("dark-theme");
    }

    /* TOGGLE SIDEBAR */
    toggleSidebar.addEventListener("click", () => {
        sidebar.classList.toggle("compact");

        if (sidebar.classList.contains("compact"))
            localStorage.setItem("sidebar", "compact");
        else
            localStorage.removeItem("sidebar");

        userDropdown.style.display = "none";
    });

    /* TOGGLE THEME */
    themeToggle?.addEventListener("click", () => {
        document.body.classList.toggle("dark-theme");
        document.body.classList.toggle("light-theme");

        if (document.body.classList.contains("dark-theme"))
            localStorage.setItem("theme", "dark");
        else
            localStorage.setItem("theme", "light");
    });

    /* ACTIVE LINK */
    const links = document.querySelectorAll(".nav-link");
    links.forEach(link => {
        if (link.href === window.location.href) {
            link.classList.add("active");
        }
    });

    /* USER DROPDOWN */
    if (userBlock && userDropdown) {

        userBlock.addEventListener("click", () => {
            const isOpen = userDropdown.style.display === "block";
            userDropdown.style.display = isOpen ? "none" : "block";
        });

        document.addEventListener("click", (e) => {
            if (!userBlock.contains(e.target) && !userDropdown.contains(e.target)) {
                userDropdown.style.display = "none";
            }
        });
    }
});