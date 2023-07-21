

function redirectToEditPage(id) {
  
    window.location.href = "editbutton.html?id=" + id;
}

function editRow() {

    var savedData = JSON.parse(localStorage.getItem("internships")) || [];


    const urlParams = new URLSearchParams(window.location.search);
    const idFromUrl = urlParams.get('id');

    console.log(idFromUrl);

    var internshipToUpdate = savedData.find(function(internship) {
        return internship.id === idFromUrl;
    });
    

    if (internshipToUpdate) {
        internshipToUpdate.id = document.getElementById("id").value;
        internshipToUpdate.name = document.getElementById("fname").value;
        internshipToUpdate.description = document.getElementById("desc").value;
        internshipToUpdate.studyArea = document.getElementById("studyArea").value;

        localStorage.setItem("internships", JSON.stringify(savedData));

        refreshTable();
    }
}


function deleteInternship(index) {
    var savedData = JSON.parse(localStorage.getItem("internships")) || [];

    if (index >= 0 && index < savedData.length) {
        var confirmDelete = confirm("Are you sure you want to delete this internship?");

        if (confirmDelete) {
            savedData.splice(index, 1);
            var table = document.getElementById("updateTable");
            table.deleteRow(index + 1);

            for (var i = 0; i < savedData.length; i++) {
                savedData[i].id = i + 1;
            }

            localStorage.setItem("internships", JSON.stringify(savedData));

            refreshTable();
        }
    }
}

function addInternship(event) {

    var id = document.getElementById("id").value;
    var name = document.getElementById("fname").value;
    var description = document.getElementById("desc").value; 
    var studyArea = document.getElementById("studyArea").value;

    var internshipData = {
        id : id,
        name: name,
        description: description,
        studyArea: studyArea
    };


    var savedData = JSON.parse(localStorage.getItem("internships")) || [];

    savedData.push(internshipData);

    localStorage.setItem("internships", JSON.stringify(savedData));

    document.getElementById("id").value = "";
    document.getElementById("fname").value = "";
    document.getElementById("desc").value = "";
    document.getElementById("studyArea").value = "nothing";


    window.location.href = "Internship.html";

    refreshTable();
}

function refreshTable() {
    var savedData = JSON.parse(localStorage.getItem("internships")) || [];

    var table = document.getElementById("updateTable");

    if(table.rows){
        console.log("POSTOJI");
    }

    for (var i = 0; i < savedData.length; i++) {
        var data = savedData[i];
        var row = table.rows[ i + 1 ];
        if (!row) {
            row = table.insertRow(i + 1);
        }
        row.innerHTML = "<td>" + data.id + "</td><td>" + data.name + "</td><td>" + data.description +  "</td><td>" + data.studyArea + 
        "</td><td><button class='edit-button' onclick='redirectToEditPage(" + data.id + ")'>Edit</button><button class='delete-button' onclick='deleteInternship(" + (i) + ")'>Delete</button></td>";
    }
}

window.addEventListener("load", function() {
    refreshTable();
});







