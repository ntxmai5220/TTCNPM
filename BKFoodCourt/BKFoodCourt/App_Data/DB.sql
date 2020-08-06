CREATE TABLE Account
(
	ID int IDENTITY (1,1) Primary key,
	Email nvarchar(325) not null,
	PassWord nchar(20) not null,
	Name nvarchar(50) not null,
	TypeAccount int not null default(0), 
);

INSERT INTO Account (Email,PassWord,Name,TypeAccount)
values
(
	'hung@gmail.com',
	'123',
	'Hùng',
	'1'
)
INSERT INTO Account (Email,PassWord,Name,TypeAccount)
values
(
	'huu@gmail.com',
	'123',
	N'Hữu',
	'1'
)
INSERT INTO Account (Email,PassWord,Name,TypeAccount)
values
(
	'huy@gmail.com',
	'123',
	'Huy',
	'2'
)
INSERT INTO Account (Email,PassWord,Name,TypeAccount)
values
(
	'mai@gmail.com',
	'123',
	'Mai',
	'3'
)
INSERT INTO Account (Email,PassWord,Name,TypeAccount)
values
(
	'minh@gmail.com',
	'123',
	'Minh',
	'3'
)

Create table Food
(
	ID int IDENTITY (1,1) Primary key,
	Name nvarchar(500) not null,
	Price int not null,
	Description nvarchar(500),
	Url1 nvarchar(4000) not null,
	Url2 nvarchar(4000), 
	Url3 nvarchar(4000),

);

INSERT INTO Food(Name,Price,Description,Url1,Url2,Url3)
values
(
	N'Cơm chiên dương châu',
	'30000',
	N'Cơm chiên Dương Châu tưởng chừng nhiều dầu mỡ, mau ngán nhưng không hề bởi sự kết hợp hài hòa giữa rau củ, thịt, rất dễ ăn lại đủ chất dinh dưỡng.',
	N'https://cdn.tgdd.vn/Files/2020/05/16/1255905/cach-lam-com-chien-duong-chau-don-gian-gion-ngon-vang-ruom-dep-mat-7.jpg',
	N'https://lh3.googleusercontent.com/alnSzOACWQ7bTFqNto87h-LNws4GduxDnBtaUIgQ_S9tZbIMtPJ7l4J0UhJciHv1-bBgdHeDyCmEHH6X-z5WTU_88iPgY-NVeQT1M-xIYcbegkxyMWHzrb7DjE84xqPsK7gq81v3krVmINewcFbhtG5Jd-7ie0SnEKq4S6rkRpeeIGOsiEZD8CDvdJq25kc9h_LQCHtdkGBUKpRKRPqUBMDWe0vCTXkC8LXAh-iL_aplgC2GjsyAOeTCNV-mSDLtQjjtd1Kuf8KQIQC4Q4jl1WQ7TWU2ySAeqaNVVdzmWoZayCB9j9mgmiYZwSWamCcXIUdCvveF1-MrRh9ARpSmrWRQcNXpEZxewB0W8st7y_QbBJ2hgCJGtpPabACP9MaPYKpbxQAy6UbQR8Oj1Ndca913kj6trEOewyqcXsQ6ECVz4Ied1WtH7AoOfDFgVU4o-aLjxQrEeiNJjxoYImbYc7Z6Ux_uKvEJS0UxVMYmYbuqxn2Ief7vnnzGH6k9yzEEoaQMH763CfbtG4ppgcSdnhlJh_wI_v5VVFTGMBFhtxiEM5V9iW2eXCfjfK1ku4575cad2I2W7biGfxa6QlGP2e5smJSVmTkdvhi6qkOm44Cz6txZIiLAJuY0-wVp3gG_9EV5ogX3h_WrTOQeFQdRWs2VvZkxrEkiAEtpuxbq6yXL0JV7fdejBz9B1gRQpA5lzw_L0Mlem7Yl3ARapkKAGKtBlg=w800-h500-no',
	N'https://toihoctiengtrung.com/wp-content/uploads/2019/03/com-chien-trung.jpg'
)
INSERT INTO Food(Name,Price,Description,Url1,Url2,Url3)
values
(
	N'Cơm sườn',
	'30000',
	N'Sự kết hợp của cơm nấu từ gạo vụn ăn kèm với các loại đồ ăn như sườn, chả trứng,...vừa thơm ngon lại đậm vị. Thưởng thức một đĩa cơm ngon chuẩn vị sẽ là một gợi ý hoàn hảo cho cả một bữa ăn ngon, đầy năng lượng.',
	N'https://media.cooky.vn/recipe/g5/47874/s480x480/recipe47874-cook-step5-636940316820312070.jpg',
	N'https://www.diadiemanuong.net.vn/upload/images2/2019/Thang%206/Quan%20an%205%20Thang/cooky-recipe-636676252579758376.jpg',
	N'https://beptruong.edu.vn/wp-content/uploads/2018/09/pha-nuoc-mam-com-tam.jpg'
)
INSERT INTO Food(Name,Price,Description,Url1,Url2,Url3)
values
(
	N'Xôi mặn',
	'15000',
	N'Món xôi mặn này được tạo thành từ rất nhiều những loại nguyên liệu khác nhau: lạp xưởng, đậu phộng, nếp, thịt xé, nếp…',
	N'https://i.ytimg.com/vi/DAAmDnzO6MI/maxresdefault.jpg',
	N'https://noiphodien123.vn/wp-content/uploads/2020/06/cach-lam-xoi-man-de-ban-don-gian.jpg',
	N'https://afamilycdn.com/zoom/640_400/2018/9/4/xoi-man-quang-dong-8-153604111152292762527-36-0-600-902-crop-15360417736591767122406.jpg'
)
INSERT INTO Food(Name,Price,Description,Url1,Url2,Url3)
values
(
	N'Bánh mì chả cá',
	'15000',
	N'Với vỏ bánh mì giòn rụm, nhân chả cá thơm ngon cùng nước sôt đặc biệt, bánh mì chả cá khiến bao người thưởng thức mê mẩn.',
	N'https://cdn-ak.f.st-hatena.com/images/fotolife/v/vuihoclambanh/20171014/20171014104651.jpg',
	N'https://i.ytimg.com/vi/ZB21VD9b3Qw/maxresdefault.jpg',
	N'https://xebanhmithonhiky.com.vn/wp-content/uploads/2019/04/banh-mi-cha-ca-ngon.jpg'
)
INSERT INTO Food(Name,Price,Description,Url1,Url2,Url3)
values
(
	N'Trứng ốp la',
	'8000',
	N'Trứng chiên thơm ngon (món ăn thêm)',
	N'https://media.cooky.vn/recipe/g2/15536/s640/recipe15536-635755988060786316.jpg',
	N'https://tiepthigiadinh.vn/wp-content/uploads/2016/05/food-breakfast-egg-milk-766x380.jpg',
	N'https://img-global.cpcdn.com/recipes/bee1e67a0b9f76d9/751x532cq70/c%C6%A1m-chien-va-tr%E1%BB%A9ng-%E1%BB%91p-la-recipe-main-photo.jpg'
)
INSERT INTO Food(Name,Price,Description,Url1,Url2,Url3)
values
(
	N'Bánh mì ốp la',
	'18000',
	N'Bánh mì, trứng và rau củ đơn giản vẫn cung cấp đầy đủ năng lượng làm việc',
	N'https://cdn-img-v2.webbnc.net/uploadv2/web/38/3881/product/2016/08/02/10/43/1470134929__mg_3868.jpg',
	N'https://cdn.beptruong.edu.vn/wp-content/uploads/2013/01/banh-mi-kep-trung.jpg',
	N'https://banhmimahai.vn/wp-content/uploads/2017/09/banh-mi-op-la-1.jpg'
)
INSERT INTO Food(Name,Price,Description,Url1,Url2,Url3)
values
(
	N'Cơm gà xối mỡ',
	'30000',
	N'Da gà giòn nhưng bên trong ngon thấm vị, cơm gạo dẻo kết hợp rau củ tươi ngon.',
	N'https://dtlscuh0h90jk.cloudfront.net/seller/photos/VNGFVN0000000r_08aad14f115a451aa20ebbf5ebe8101e.jpg',
	N'https://i.ytimg.com/vi/swj3xKUmIio/hqdefault.jpg',
	N'https://www.huongnghiepaau.com/wp-content/uploads/2018/07/com-ga-xoi-mo.jpg'
)
INSERT INTO Food(Name,Price,Description,Url1,Url2,Url3)
values
(
	N'Khoai tây chiên',
	'15000',
	N'Khoai tây chiên nóng giòn, thơm ngon cùng với nước chấm đậm đà.',
	N'https://cdn.tgdd.vn/Files/2017/11/27/1045160/bi-quyet-chien-khoai-tay-thom-ngon-gion-rum-an-hoai-khong-chan-2.jpg',
	N'https://daubepgiadinh.vn/wp-content/uploads/2018/05/cach-lam-khoai-tay-chien-gion-600x397.jpg',
	N'https://cdn.tgdd.vn/Files/2017/11/27/1045160/bi-quyet-chien-khoai-tay-thom-ngon-gion-rum-an-hoai-khong-chan-6.jpg'
)
INSERT INTO Food(Name,Price,Description,Url1,Url2,Url3)
values
(
	N'Mì Ý',
	'30000',
	N'Mì Ý  kết hợp với xốt cà chua thịt bò với nhiều loại gia vị như: húng, dầu ôliu, thịt hoặc rau… ',
	N'https://daynauan.info.vn/wp-content/uploads/2018/03/cach-lam-nuoc-xot-mi-y.jpg',
	N'https://www.huongnghiepaau.com/wp-content/uploads/2016/05/mi-y-xot-thit-bo-bam.jpg',
	N'https://daynauan.info.vn/wp-content/uploads/2018/03/hinh-mi-y-xot-bo-bam.jpg'
)
INSERT INTO Food(Name,Price,Description,Url1,Url2,Url3)
values
(
	N'Gà rán',
	'20000',
	N'Da gà giòn, thơm, ráo dầu, thịt gà chín nhưng vẫn giữ được độ ẩm, thịt mềm mượt, tươi rói.',
	N'https://cdn.tgdd.vn/Files/2018/05/28/1091506/cach-lam-ga-ran-vi-nhu-ga-kfc-sieu-ngon-cuc-de-lam-tai-nha-2.jpg',
	N'https://d1sag4ddilekf6.cloudfront.net/compressed/merchants/VNGFVN00000a2v/hero/2f7ec65ef2f9416893bb7515bf285844_1582994074628156129.jpg',
	N'https://static.hotdeal.vn/images/454/454122/500x500/60993-he-thong-texas-chicken-thuong-hieu-ga-ran-hang-dau-the-gioi.jpg'
)
INSERT INTO Food(Name,Price,Description,Url1,Url2,Url3)
values
(
	N'Hamburger',
	'25000',
	N'Với lớp bánh thơm lừng quyện cùng phần nhân béo ngậy và những loại rau củ tươi giòn ăn kèm.',
	N'https://food.fnr.sndimg.com/content/dam/images/food/fullset/2004/2/25/0/bw2b07_hambugers1.jpg.rend.hgtvcom.616.462.suffix/1558017418187.jpeg',
	N'https://foremangrillrecipes.com/wp-content/uploads/2013/05/american-hamburger-foreman-grill.jpg',
	N'https://img.taste.com.au/hoyK5oCA/taste/2016/11/hamburger-with-caramelised-pineapple-90338-1.jpeg'
)
INSERT INTO Food(Name,Price,Description,Url1,Url2,Url3)
values
(
	N'Sandwich',
	'20000',
	N'Với trứng, thịt nguội, cá và một ít bơ kết hợp với các loại rau đầy đủ dinh dưỡng cho một phần ăn.',
	N'https://imagesvc.meredithcorp.io/v3/mm/image?url=https%3A%2F%2Fimg1.cookinglight.timeinc.net%2Fsites%2Fdefault%2Ffiles%2Fstyles%2F4_3_horizontal_-_1200x900%2Fpublic%2F1556744250%2Fthe-ultimate-veggie-sandwich-1905.jpg%3Fitok%3DrAOvFAhQ',
	N'https://realfood.tesco.com/media/images/RFO-1400x919-ChickenClubSandwich-0ee77c05-5a77-49ac-a3bd-4d45e3b4dca7-0-1400x919.jpg',
	N'https://realfood.tesco.com/media/images/RFO-1400x919-Pesto-club-sandwich-49fdd81d-d37b-46f1-a998-0309a2345baf-0-1400x919.jpg'
)
INSERT INTO Food(Name,Price,Description,Url1,Url2,Url3)
values
(
	N'Cơm trộn',
	'35000',
	N'Kết hợp hài hòa giữa nhiều loại nguyên liệu, thơm ngon, đầy đủ dinh dưỡng',
	N'https://znews-photo.zadn.vn/w660/Uploaded/wyhktpu/2017_04_07/2.jpg',
	N'https://vyctravel.com/libs/upload/ckfinder/images/Han/Bimbimbap.jpg',
	N'https://media.cooky.vn/recipe/g1/622/s480x480/recipe622-prepare-step6-635513136413316250.JPG'
)
INSERT INTO Food(Name,Price,Description,Url1,Url2,Url3)
values
(
	N'Kem tươi',
	'12000',
	N'Béo ngọt và mát lạnh',
	N'https://cdn.vatgia.vn/pictures/fullsize/2017/05/30/kds1496129395.jpg',
	N'https://cf.shopee.vn/file/b4b5bad067aaa3255256ddc2a5cd722e',
	N'https://kemocvit09.files.wordpress.com/2013/05/kem-merino.jpg'
)
INSERT INTO Food(Name,Price,Description,Url1,Url2,Url3)
values
(
	N'Mì Quảng',
	'30000',
	N'Bát mì nóng hổi, thơm ngon độc đáo có sự kết hợp hài hòa giữa sợi mì mềm dai, thịt gà thơm béo, nước dùng đậm đà, rau sống tươi giòn.',
	N'https://danang.huongnghiepaau.com/images/mon-ngon-mien-trung/mi-quang-ga.jpg',
	N'https://giadinh.mediacdn.vn/2019/5/13/photo-0-15577176697201172222642.jpg',
	N'https://i.pinimg.com/originals/c4/15/5b/c4155b85827a87e5fd207e7f560108c5.jpg'
)
INSERT INTO Food(Name,Price,Description,Url1,Url2,Url3)
values
(
	N'Mì xào hải sản',
	'35000',
	N'Sự hòa quyện hương vị của mì và các loại hải sản, chút thanh ngọt, chua nhẹ khiến người ăn thích thú mà không bị ngấy.',
	N'https://beptruong.edu.vn/wp-content/uploads/2013/08/mon-mi-xao-hai-san.jpg',
	N'https://hoclaixehcm.edu.vn/wp-content/uploads/2018/07/cay_du_quan_mi_xao_hai_san.jpg',
	N'https://media.cooky.vn/recipe/g5/46651/s320x320/cooky-recipe-636891049844806144.JPG'
)
INSERT INTO Food(Name,Price,Description,Url1,Url2,Url3)
values
(
	N'Mì xào bò',
	'35000',
	N'Mì xào bò là một món ăn ngon, hấp dẫn. Những sợi mì xào dai dai, thịt bò xào mềm thơm thấm gia vị, cùng nấm, rau củ giàu chất sơ và vitamin thiết yếu cho cơ thể.',
	N'https://bayleefood.com/wp-content/uploads/2020/03/mi-xao-bo-600x506.png',
	N'https://www.cet.edu.vn/wp-content/uploads/2019/06/mi-xao-bo.jpg',
	N'https://nghebep.com/wp-content/uploads/2017/10/mon-mi-xao-bo.jpg'
)
INSERT INTO Food(Name,Price,Description,Url1,Url2,Url3)
values
(
	N'Phở bò',
	'40000',
	N'Thành phần chính của Phở bò gồm có bánh phở, thịt bò và nước dùng được hầm bằng xương bò, kết hợp với nhiều loại gia vị khác như quế, hồi, gừng, thảo quả, đinh hương... ',
	N'https://cdn.tgdd.vn/Files/2018/06/14/1095399/huong-dan-chi-tiet-cach-nau-pho-bo-thom-ngon-bo-duong-cho-ca-nha.png',
	N'https://images.foody.vn/res/g77/767322/prof/s576x330/foody-upload-api-foody-mobile-pho-1-jpg-180807101645.jpg',
	N'https://m.baotuyenquang.com.vn/media/images/2019/06/img_20190604090908.jpg'
)
INSERT INTO Food(Name,Price,Description,Url1,Url2,Url3)
values
(
	N'Phở gà',
	'32000',
	N'Phở gà được kết hợp từ những miếng thịt gà ngọt thơm và mềm, rau giá ngọt ngọt giòn giòn với những sợi bún mềm mềm dai dai.',
	N'https://sohanews.sohacdn.com/thumb_w/660/2019/9/2/photo-1-15674321560261250979530-crop-1567432188122520860796.jpg',
	N'https://nld.mediacdn.vn/thumb_w/540/2020/3/13/photo-1-15840710571471812455194.jpg',
	N'https://dl.airtable.com/cVDipJQcQb6OVY7ZV4QN_phoga-large%402x.jpg.jpg'
)
INSERT INTO Food(Name,Price,Description,Url1,Url2,Url3)
values
(
	N'Bò kho bánh mì',
	'40000',
	N'Thịt bò mềm, độ dai vừa phải, mùi thơm hấp dẫn của các loại gia vị đặc trưng không thể nhầm lẫn vào đâu. Bò kho ăn kèm với ổ bánh mì nóng và ít rau thơm.',
	N'https://thucthan.com/media/2018/05/bo-kho/bo-kho.jpg',
	N'https://i.ytimg.com/vi/KFPdOaY3wCg/maxresdefault.jpg',
	N'https://beptruong.edu.vn/wp-content/uploads/2013/07/cach-nau-bo-kho-ngon.jpg'
)
INSERT INTO Food(Name,Price,Description,Url1,Url2,Url3)
values
(
	N'Bánh mì',
	'4000',
	N'Bánh mì không nóng giòn có thể ăn cùng bò kho',
	N'https://blogvietcook.weebly.com/uploads/1/1/1/1/111116433/cach-lam-banh-mi-khong-can-bot-no_orig.jpg',
	N'https://i.imgur.com/4x5Bv24.png',
	N'https://www.thuocdantoc.org/wp-content/uploads/2019/08/banh-mi-chuot.jpg'
)
INSERT INTO Food(Name,Price,Description,Url1,Url2,Url3)
values
(
	N'Hủ tiếu khô',
	'30000',
	N'Hủ tiếu khô cùng với gan, tôm, thịt, trứng…sợi hủ tiếu dai mềm và nước sốt trộn đậm đà gia vị.',
	N'https://chabocole.com/wp-content/uploads/2020/04/hu-tieu-kho-da-nang-1.jpg',
	N'https://chabocole.com/wp-content/uploads/2020/04/hu-tieu-kho-da-nang-1.jpg',
	N'https://img-global.cpcdn.com/recipes/90267c96d71f1775/1200x630cq70/photo.jpg'
)
INSERT INTO Food(Name,Price,Description,Url1,Url2,Url3)
values
(
	N'Hủ tiếu sườn',
	'30000',
	N'Sợi hủ tiếu dai ngon, sườn tươi ngọt, nước súp đậm đà.',
	N'https://luhanhvietnam.com.vn/du-lich/vnt_upload/news/05_2020/mon-an-truyen-thong-cua-nguoi-khmer-duoc-cai-bien.jpg',
	N'https://vcdn-suckhoe.vnecdn.net/2017/07/31/hu-tieu-7418-1501468381_1200x0.jpg?w=0&h=0&q=100&dpr=2&fit=crop&s=ECXWQivsCbNfSF4oISFfAA',
	N'https://daubepgiadinh.vn/wp-content/uploads/2018/12/hu-tieu-suon-heo-600x400.jpg'
)
INSERT INTO Food(Name,Price,Description,Url1,Url2,Url3)
values
(
	N'Bún bò Huế',
	'40000',
	N'Thịt nạm thái mỏng, móng chặt miếng vừa, thịt chân giò thái mỏng, tiết bò cắt như giò. Giò hoặc chả huế nếu có thì cho thêm vào. Hành, mùi tàu, hành tây thái mỏng ngâm nước đá cho bớt hăng. Rau thơm chuẩn bị ăn kèm gồm hoa chuối, húng chó, mùi tàu, mùi ta xà lách. Khi ăn vắt thêm chanh cho tăng thêm phần thơm ngon.',
	N'https://photo-1-baomoi.zadn.vn/w1000_r1/2020_02_18_541_34005417/b78d393a1079f927a068.jpg',
	N'https://cdn.cet.edu.vn/wp-content/uploads/2018/03/bun-bo-hue-1.jpg',
	N'https://ameovat.com/wp-content/uploads/2016/04/bun-bo-hue-ngon-02.jpg'
)
INSERT INTO Food(Name,Price,Description,Url1,Url2,Url3)
values
(
	N'Bánh canh',
	'30000',
	N'Sợi bánh canh mềm, dẻo, trắng trong, được làm từ bột lọc với bột gạo, nước dùng được hầm kỹ bằng xương heo và nhiều loại hải sản nên có vị ngọt thanh rất đặc trưng, đậm đà, không quá gắt.',
	N'https://img-global.cpcdn.com/recipes/d279959e1ad81f30/751x532cq70/banh-canh-gio-heo-recipe-main-photo.jpg',
	N'https://cdn.tgdd.vn/Files/2018/07/25/1104100/huong-dan-chi-tiet-cach-nau-banh-canh-trang-bang-thom-ngon-tai-nha-6.jpg',
	N'https://vcdn-dulich.vnecdn.net/2019/01/12/VnExpressbanhcanhSaiGonchoTanD-5168-8414-1547286700.jpg'
)
INSERT INTO Food(Name,Price,Description,Url1,Url2,Url3)
values
(
	N'Sinh tố dâu',
	'20000',
	N'Sinh tố dâu tươi ngon, nguyên liệu sạch cung cấp vitamin và chất dinh dưỡng.',
	N'https://cdn.tgdd.vn/Files/2019/03/29/1157565/tu-lam-sinh-to-dau-tai-nha-thom-ngon-beo-min-2_800x1200.jpg',
	N'https://ameovat.com/wp-content/uploads/2017/03/cach-lam-sinh-to-dau-600x452.jpeg',
	N'https://image-us.eva.vn/upload/2-2019/images/2019-05-03/5-cach-lam-sinh-to-dau-giai-nhiet-mua-he-cach-lam-sinh-to-dau-4-1556856070-732-width600height450.jpg'
)
INSERT INTO Food(Name,Price,Description,Url1,Url2,Url3)
values
(
	N'Sinh tố bơ',
	'20000',
	N'Sinh tố bơ thơm ngon, béo ngậy có tác dụng làm đẹp và chứa nhiều chất dinh dưỡng tốt cho sức khỏe.',
	N'https://thucthan.com/media/2018/06/sinh-to-bo/sinh-to-bo.jpg',
	N'https://cdn.tgdd.vn/Files/2016/03/14/802181/cach-lam-sinh-to-bo-ngon-beo-ngot-dung-vi-4.jpg',
	N'https://cdn.tgdd.vn/Files/2018/05/29/1091772/3-cach-lam-sinh-to-bo--12.jpg'
)
INSERT INTO Food(Name,Price,Description,Url1,Url2,Url3)
values
(
	N'Matcha đá xay',
	'25000',
	N'Kem tươi béo, sữa tạo nên vị ngọt kết hợp với bột matcha và đá xay.',
	N'https://1.bp.blogspot.com/-fTLgN-cWt_8/XKyyU9DWZ-I/AAAAAAAAAGQ/WcFDwz2hY2s5ug1aYoKLamNoIndNdG3_QCLcBGAs/s1600/56764456_392887221265559_7190463058156716032_n.jpg',
	N'https://trasuan2.files.wordpress.com/2018/08/dscf4664-e1533142689109.jpg?w=300&h=300',
	N'https://cafedidong.vn/wp-content/uploads/2019/01/CAFEDIDONG-MATCHA-%C4%90%C3%81-XAY-1-300x200.jpg'
)
INSERT INTO Food(Name,Price,Description,Url1,Url2,Url3)
values
(
	N'Cà phê đen đá',
	'15000',
	N'Từ hạt cà phê nguyên chất, thơm ngon, cho một ngày tỉnh táo.',
	N'https://media.foody.vn/res/g21/206337/prof/s/foody-upload-api-foody-mobile-cafe-den-d-190926140208.jpg',
	N'https://quangtanhoa.com/wp-content/uploads/2018/01/cach-pha-ca-phe-den-da-ngon-nhu-nao-bi-quyet-pha-ca-phe-nhanh-2.jpg',
	N'https://comgasg.com/wp-content/uploads/2019/11/cafe-da-3.jpg'
)
INSERT INTO Food(Name,Price,Description,Url1,Url2,Url3)
values
(
	N'Cà phê sữa đá',
	'18000',
	N'Vị béo ngọt của sữa kết hợp với hương thơm và vị đăng đắng của cà phê.',
	N'https://caphenguyenchat.vn/wp-content/uploads/2018/05/pha-che-cafe-ly-thuy-tinh.jpg',
	N'https://media.cooky.vn/recipe/g4/39536/s800x500/cooky-recipe-cover-r39536.jpg',
	N'https://afamilycdn.com/zoom/640_400/2018/8/8/2-15337267171921813369837-25-0-485-736-crop-1533729446152193095778.jpg'
)
INSERT INTO Food(Name,Price,Description,Url1,Url2,Url3)
values
(
	N'Sữa tươi trân châu đường đen',
	'25000',
	N'Sữa tươi trân châu ngọt thanh mát từ đường đen, vị bùi bùi dai dai của trân châu kết hợp vị béo của sữa hấp dẫn.',
	N'https://images.foody.vn/res/g76/757738/prof/s576x330/foody-upload-api-foody-mobile-bbbc-jpg-180706140824.jpg',
	N'https://monngonmoingay.com/wp-content/uploads/2018/06/5ae59b55854b4-duong-den1.jpg',
	N'https://cf.shopee.vn/file/8e3b9b9d57559962a52c7699f98a0c67'
)

Create table DonHang
(
	ID int IDENTITY (1,1) Primary key,
	OrderCode varchar(100) not null,
	NumFood int not null,
	CustomerID int not null,
	Price int not null,
	Timer datetime not null,
	State int not null,
	Foreign key(CustomerID) REFERENCES dbo.Account(ID),
);

Create table OrderDetail
(
	ID int IDENTITY (1,1) Primary key,
	FoodID int not null,
	Quantily int not null,
	OrderID int not null,
	Foreign key(FoodID) REFERENCES dbo.Food(ID),
	Foreign key(OrderID) REFERENCES dbo.DonHang(ID),
);

CREATE TABLE Notification
(
	ID int IDENTITY (1,1) Primary key,
	CustomerID int,
	DonHangID int,
	Infomation nvarchar(1000),
	State bit not null default(0),
	Timer Date not null,
	Foreign key(CustomerID) REFERENCES dbo.Account(ID),
	Foreign key(DonHangID) REFERENCES dbo.DonHang(ID)
);
