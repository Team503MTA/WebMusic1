
        /*    Navbar active    */
    
        $(document).ready(function(){
        $("ul.navbar-left li").click(function(){
            $("ul.navbar-left li.livetag").removeClass("livetag");
            $(this).addClass("livetag");
        });
        });
   

        /*      banner    */

        $(document).ready(function () {
            var endimg = $(".banner-img:last").attr("stt");
            var curli = $(".slider-banner-li-active").attr("stt");
            if (curli === "0") {
                $(".div-banner .btn-items").hide();
            }
            $(".slider-banner-li").on("click", function(){
                curli = $(this).attr("stt");
                if (curli === "0") {
                    $(".div-banner .btn-items").hide();
                } else {
                    $(".div-banner .btn-items").show();
                }
                $(".banner-img-active").removeClass("banner-img-active");
                $(".slider-banner-li-active").removeClass("slider-banner-li-active");
                $(".banner-img").eq(curli).addClass("banner-img-active");
                $(".slider-banner-li").eq(curli).addClass("slider-banner-li-active");
            });
            
            function changeimg(){
                if(curli < endimg)
                {
                    curli++;
                }
                else
                {
                    curli = 0;
                }
                $(".banner-img-active").removeClass("banner-img-active");
                    $(".slider-banner-li-active").removeClass("slider-banner-li-active");
                    $(".banner-img").eq(curli).addClass("banner-img-active");
                    $(".slider-banner-li").eq(curli).addClass("slider-banner-li-active");
            }
           
            var change = setInterval(changeimg, 4000);
           $(".main-banner").on("mouseover",  function(){
                clearInterval(change);
           });
           $(".main-banner").on("mouseout",  function(){
                change = setInterval(changeimg, 4000);
           });
           });
            
            /*      content    */
            $(document).ready(function() {
                
                /*    main-content-slider    */
            $(".main-content-1 .slider-content-li").on("click", function(){
            var curli1 = $(this).attr("stt");
            $(".main-content-1 .packs-active").removeClass("packs-active");
            $(".main-content-1 .slider-content-li-active").removeClass("slider-content-li-active");
                $(".main-content-1 .packs").eq(curli1).addClass("packs-active");
            $(".main-content-1 .slider-content-li").eq(curli1).addClass("slider-content-li-active");
            });
                $(".main-content-2 .slider-content-li").on("click", function(){
            var curli2 = $(this).attr("stt");
            $(".main-content-2 .packs-active").removeClass("packs-active");
            $(".main-content-2 .slider-content-li-active").removeClass("slider-content-li-active");
                    $(".main-content-2 .packs").eq(curli2).addClass("packs-active");
            $(".main-content-2 .slider-content-li").eq(curli2).addClass("slider-content-li-active");
                });

                /*        main-content-1    */
            $(".main-content-1 .slider-direction:last-child").on("click", function(){
                var nextpack = $(".main-content-1 .packs-active").next();
                var sttnext = nextpack.attr("stt");
                $(".main-content-1 .slider-content-li-active").removeClass("slider-content-li-active");
                $(".main-content-1 .packs-active").removeClass("packs-active");     
                if(sttnext == null)
                {
                    $(".main-content-1 .packs:first").addClass("packs-active");
                    $(".main-content-1 .slider-content-li:first").addClass("slider-content-li-active");
                }
                else
                {
                    nextpack.addClass("packs-active");
                    $(".main-content-1 .slider-content-li").eq(sttnext).addClass("slider-content-li-active");
                }
            });
                $(".main-content-1 .slider-direction:first-child").on("click", function(){
                var prevpack = $(".main-content-1 .packs-active").prev();
                    var sttprev = prevpack.attr("stt");
                    $(".main-content-1 .slider-content-li-active").removeClass("slider-content-li-active");
                $(".main-content-1 .packs-active").removeClass("packs-active");     
                if(sttprev == null)
                {
                    $(".main-content-1 .packs:last").addClass("packs-active");
                    $(".main-content-1 .slider-content-li:last").addClass("slider-content-li-active");
                }
                else
                {
                    prevpack.addClass("packs-active");
                    $(".main-content-1 .slider-content-li").eq(sttprev).addClass("slider-content-li-active");
                }
                });

                /*   main-content-2    */
                $(".main-content-2 .slider-direction:last-child").on("click", function(){
                var nextpack = $(".main-content-2 .packs-active").next();
                    var sttnext = nextpack.attr("stt");
                    $(".main-content-2 .slider-content-li-active").removeClass("slider-content-li-active");
                $(".main-content-2 .packs-active").removeClass("packs-active");     
                if(sttnext == null)
                {
                    $(".main-content-2 .packs:first").addClass("packs-active");
                    $(".main-content-2 .slider-content-li:first").addClass("slider-content-li-active");
                }
                else
                {
                    nextpack.addClass("packs-active");
                    $(".main-content-2 .slider-content-li").eq(sttnext).addClass("slider-content-li-active");
                }
                });
                $(".main-content-2 .slider-direction:first-child").on("click", function(){
                var prevpack = $(".main-content-2 .packs-active").prev();
                    var sttprev = prevpack.attr("stt");
                    $(".main-content-2 .slider-content-li-active").removeClass("slider-content-li-active");
                $(".main-content-2 .packs-active").removeClass("packs-active");     
                if(sttprev == null)
                {
                    $(".main-content-2 .packs:last").addClass("packs-active");
                    $(".main-content-2 .slider-content-li:last").addClass("slider-content-li-active");
                }
                else
                {
                    prevpack.addClass("packs-active");
                    $(".main-content-2 .slider-content-li").eq(sttprev).addClass("slider-content-li-active");
                }
                });
            });
            
            /*    menu    */
            $(document).ready(function() {
            /* GENRES*/
            $(".btn-menu:first").on("mouseover",function(){
                $(".btn-li:first .drop-shadow").css("display","block");
            });
                $(".dropdown-menu-parent li:first .drop-shadow").on("mouseover",function(){
                $(".btn-li:first .drop-shadow").css("display","block");
                });
                $(".btn-menu:first").on("mouseout",function(){
                $(".btn-li:first .drop-shadow").css("display","none");
                });
                $(".btn-li:first .drop-shadow").on("mouseout",function(){
                $(".btn-li:first .drop-shadow").css("display","none");
                });

                /*EXPLORE*/
            $(".btn-li:nth-child(2) .btn-menu").on("mouseover",function(){
                $(".btn-li:nth-child(2) .drop-shadow").css("display","block");
            });
                $(".btn-li:nth-child(2) .drop-shadow").on("mouseover",function(){
                $(".btn-li:nth-child(2) .drop-shadow").css("display","block");
                });
                $(".btn-li:nth-child(2) .btn-menu").on("mouseout",function(){
                $(".btn-li:nth-child(2) .drop-shadow").css("display","none");
                });
                $(".btn-li:nth-child(2) .drop-shadow").on("mouseout",function(){
                $(".btn-li:nth-child(2) .drop-shadow").css("display","none");
                });

                /*LABELS*/
            $(".btn-li:last .btn-menu").on("mouseover",function(){
                $(".btn-li:last .drop-shadow").css("display","block");
            });
                $(".btn-li:last .drop-shadow").on("mouseover",function(){
                $(".btn-li:last .drop-shadow").css("display","block");
                });
                $(".btn-li:last .btn-menu").on("mouseout",function(){
                $(".btn-li:last .drop-shadow").css("display","none");
                });
                $(".btn-li:last .drop-shadow").on("mouseout",function(){
                $(".btn-li:last .drop-shadow").css("display","none");
                });
            });


            /*    rut gon the a   */
            $(document).ready(function() {
            $(".btn-li a").each(function() {
            var text = $(this).text();

            if(text.length > 17){
              text = text.substring(0,14) + "...";
              $(this).html(text);
            }
            });
            });

  
            /*    login     */
            $(document).ready(function(){
            $("#login").on("click", function(){
                $(".navbar .login, .navbar .div-login").css("display","block");
            });
                $(".btn-close").on("click",function(){
                $(".navbar .login, .navbar .div-login").css("display","none");
                });

                /*create account*/
            $("#create-account").on("click", function(){
                $(".navbar .create, .navbar .div-create").css("display","block");
            });
                $(".btn-close").on("click",function(){
                $(".navbar .create, .navbar .div-create").css("display","none");
                });
            });



