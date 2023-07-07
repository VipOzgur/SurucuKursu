
    //Burası galery le alakalı /İnput ekliyorum
    $(document).ready(function () {
        $('.parent').each(function () {
          var id = $(this).find("img").attr("id");
          inputElement = '<input class="inputImg" type="checkbox" id="' + id + '">';
          $(this).append(inputElement);
        });

        //Aktif inputları alıp formdaki inputa atıyorum
        $(".inputImg").on("change", function () {
          if ($(this).is(":checked")) {
            $(this).addClass("aktifler");
          }else{
              $(this).removeClass("aktifler");
          }
            var ids = $('.aktifler').map(function () {
            return this.id;
          }).get();
          if (ids.length > 0) {
              $("#send").attr("value", ids.join(","));
              $("#btnSubmit").prop("disabled", false);
          }else{
              $("#send").attr("value","");
              $("#btnSubmit").prop("disabled", true);
          }
        });
      
      });

