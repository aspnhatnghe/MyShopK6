# MyShopK6
Đồ án ASP.NET Core khóa 6

## Buổi 04 (21/07/2019)
* Thiết kế Layout hiển thị chi tiết sản phẩm
* Sử dụng Session để làm giỏ hàng

## Buổi 03 (20/07/2019)
* Thiết kế Layout dạng List/Grid để hiển thị sản phẩm
* Trong đó sử dụng AutoMapper để map các đối tượng:
  - Bước 1: Cài Nuget: `AutoMapper.Extensions.Microsoft.DependencyInjection`
  - Bước 2: Vào hàm `ConfigureServices` của StartUp thêm lệnh: `services.AddAutoMapper();`
  - Bước 3: Khai báo map giữa các kiểu dữ liệu: `CreateMap<HangHoa, HangHoaView>().ReverseMap();`
  - Bước 4: Thực hiện map kiểu dữ liệu:
      - Ví dụ trong Controller khai báo IMapper dạng DI
      - và gọi `mapper.Map<DestinationType>(source);` để chuyển đổi dữ liệu

## Buổi 02 (14/07/2019)
* Thiết kế hoàn chỉnh chức năng CRUD hàng hóa (trong area Admin)
  - Tạo partial view dùng để hiển thị menu 2 cấp
  - Tạo hàm thực hiện upload file vào thư mục chỉ định
  - Nhúng thư viện `Sweet Alert 2` và `CKEditor 5`/`summernote` vào view
  
## Buổi 01 (13/07/2019)
* Thiết kế layout frontend (dựa vào shopmart-html.zip)
* Xây dựng CSDL gồm các model Loai và HangHoa
* Xây dựng menu ngang sử dụng ViewComponent
* Thiết kế template backend đơn giản dùng BootStrap 4.x
* Tạo `area` Admin để thực hiện CRUD hàng hóa
  - Tạo file `_ViewStart.cshtml` để khai báo template layout chung cho area này
  - Tạo file `_ViewImports.cshtml` để khai báo thư viện TagHelper,...