function myFunc(input) {

    var files = input.files || input.currentTarget.files;

    var reader = [];
    var images = document.getElementById('images');
    var name;
    for (var i in files) {
        if (files.hasOwnProperty(i)) {
            name = 'file' + i;

            reader[i] = new FileReader();
            reader[i].readAsDataURL(input.files[i]);

            images.innerHTML += '<img id="' + name + '" src="" />';

            (function (name) {
                reader[i].onload = function (e) {
                    console.log(document.getElementById(name));
                    document.getElementById(name).src = e.target.result;
                };
            })(name);


            console.log(files[i]);
        }
    }
}

async function createUser() {
    var formData = JSON.stringify($("#myForm").serializeArray());
    const response = await fetch("https://localhost:7155/api/Ads/CreateAd", {
        method: "POST",
        // headers: { 
        //         'Accept': 'application/json',
        //         'Content-Type': 'application/json'},
        body: new FormData(myForm)
    });

    const content = await response.json();

    console.log(content);
}

