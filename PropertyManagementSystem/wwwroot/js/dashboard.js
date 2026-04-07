document.addEventListener("DOMContentLoaded", () => {

    const sidebar = document.getElementById("sidebar");
    const toggleSidebar = document.getElementById("toggleSidebar");
    const themeToggle = document.getElementById("themeToggle");

    if (localStorage.getItem("sidebar") === "compact") {
        sidebar.classList.add("compact");
    }

    if (localStorage.getItem("theme") === "dark") {
        document.body.classList.remove("light-theme");
        document.body.classList.add("dark-theme");
    }

    toggleSidebar.addEventListener("click", () => {
        sidebar.classList.toggle("compact");

        if (sidebar.classList.contains("compact"))
            localStorage.setItem("sidebar", "compact");
        else
            localStorage.removeItem("sidebar");
    });

    themeToggle.addEventListener("click", () => {
        document.body.classList.toggle("dark-theme");
        document.body.classList.toggle("light-theme");

        if (document.body.classList.contains("dark-theme"))
            localStorage.setItem("theme", "dark");
        else
            localStorage.setItem("theme", "light");
    });

    const links = document.querySelectorAll(".nav-link");
    links.forEach(link => {
        if (link.href === window.location.href) {
            link.classList.add("active");
        }
    });
}); 