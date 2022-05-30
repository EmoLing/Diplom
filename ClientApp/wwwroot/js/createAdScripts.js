$("#kindofanimals").on('change', function () {
    if ($(this).val() == "other") {
        $("#otherkind").show();
    } else {
        $("#otherkind").hide();
    }
})

$("#colorofanimals").on('change', function () {
    if ($(this).val() == "other") {
        $("#othercolor").show();
    } else {
        $("#othercolor").hide();
    }
})

document.addEventListener("DOMContentLoaded", function (event) {

    var bar = document.getElementById("js-progressbar");

    UIkit.upload(".js-upload", {

        url: "/home/SaveFiles",
        multiple: true,
        beforeSend: function () {
            console.log("beforeSend", arguments);
        },
        beforeAll: function () {
            console.log("beforeAll", arguments);
        },
        load: function () {
            console.log("load", arguments);
        },
        error: function () {
            console.log("error", arguments);
        },
        complete: function () {
            console.log("complete", arguments);
        },

        loadStart: function (e) {
            console.log("loadStart", arguments);

            bar.removeAttribute("hidden");
            bar.max = e.total;
            bar.value = e.loaded;
        },

        progress: function (e) {
            console.log("progress", arguments);

            bar.max = e.total;
            bar.value = e.loaded;
        },

        loadEnd: function (e) {
            console.log("loadEnd", arguments);

            bar.max = e.total;
            bar.value = e.loaded;
        },

        completeAll: function () {
            console.log("completeAll", arguments);

            setTimeout(function () {
                bar.setAttribute("hidden", "hidden");
            }, 1000);

            UIkit.modal.alert('Загрузка завершена!');
        }

    });

});
