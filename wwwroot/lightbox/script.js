
    //Burası galery le alakalı
    $(document).ready(function () {
        $('.parent').each(function () {
          var id = $(this).find("img").attr("id");
          inputElement = '<input class="inputImg" type="checkbox" id="' + id + '">';
          $(this).append(inputElement);
        });
      
        $(".inputImg").on("change", function () {
          if ($(this).is(":checked")) {
            $(this).addClass("active");
          }else{
            $(this).removeClass("active");
          }
            var ids =$('.active').map(function () {
            return this.id;
          }).get();
          if (ids.length > 1) {
            console.log(ids);
            var p = $("#pTagi");
            p.text(ids);
  
              $("#send").attr("value", ids.join(","));
            
              $("#submit").prop("disabled", false);
            }else{
              $("#send").attr("value","");
              $("#pTagi").text("");
              $("#submit").prop("disabled", true);
            }
          
        });
      
      });

