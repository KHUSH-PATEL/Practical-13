// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function toggleBtn() {
    var t = document.getElementById("myBtn");
    if (t.value == "Show Columns") {
        document.getElementById("showColumnsBtn").addEventListener("click", function () {
            document.getElementById("employeeTable").style.display = "table";
        });
        t.value = "Hide Columns";
    }
    else if (t.value == "Hide Columns") {
        document.getElementById("showColumnsBtn").addEventListener("click", function () {
            document.getElementById("employeeTable").style.display = "none";
        });
        t.value = "Show Columns";
    }
}