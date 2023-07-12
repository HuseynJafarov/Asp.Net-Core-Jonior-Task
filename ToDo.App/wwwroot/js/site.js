document.addEventListener("keyup", function (event) {
    if (event.target.id === "searchinp") {
        let inputVal = event.target.value.trim();
        let searchListItems = document.querySelectorAll(".search-list-p li");
        searchListItems.forEach(function (item) {
            item.parentNode.removeChild(item);
        });

        let xhr = new XMLHttpRequest();
        xhr.open("GET", "home/search?search=" + inputVal);
        xhr.onreadystatechange = function () {
            if (xhr.readyState === 4 && xhr.status === 200) {
                let res = xhr.responseText;
                let searchListP = document.querySelector(".search-list-p");
                searchListP.innerHTML = res;
            }
        };
        xhr.send();
    }
});
