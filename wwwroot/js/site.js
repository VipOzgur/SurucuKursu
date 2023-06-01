document.getElementById('imageInput').addEventListener('change', function (event) {
    var imagePreview = document.getElementById('imagePreview');
    imagePreview.innerHTML = ''; // Önceki önizlemeleri temizle

    var files = event.target.files;
    for (var i = 0; i < files.length; i++) {
        var file = files[i];
        var reader = new FileReader();

        reader.onload = function (e) {
            var imageElement = document.createElement('img');
            imageElement.src = e.target.result;
            imageElement.classList.add('preview-image');
            imagePreview.appendChild(imageElement);
        };

        reader.readAsDataURL(file);
    }
});
