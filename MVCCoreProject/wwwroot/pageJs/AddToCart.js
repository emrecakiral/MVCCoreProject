

$(document).ready(function () {

	$(".addshopingcart").click(function () {

		var prodId = $(this).data("productid"); // data ile başlayan attribueleri yakalar.. data-...
		console.log(prodId);

		$.ajax({
			type: "POST",
			url: "/Cart/AddtoCart",
			data: { productId: prodId },
			//contentType:"application/json",
			dataType: "json",
			success: function (r) {

				console.log(r);

				var toplamAdet = 0;
				var toplamFiyat = 0;
				for (var i = 0; i < r.length; i++) {
					toplamAdet += r[i].adet;
					toplamFiyat += r[i].fiyat;
				}
				$(".cartAdet").html(toplamAdet);
				$(".cartFiyat").html("$" + toplamFiyat);

				$("html, body").animate({ scrollTop: 0 }, "slow");

			}
		});


		//var prodId2 = $(this).attr("data-productId"); // atrribute seçici
		//console.log(prodId2);

	});
});