// تفعيل تأثيرات السايدبار
document.addEventListener('DOMContentLoaded', function () {
    // تحديد العنصر النشط
    const currentPath = window.location.pathname;
    document.querySelectorAll('.sidebar-item').forEach(item => {
        if (item.getAttribute('href') === currentPath) {
            item.classList.add('active');
        }
    });

    // إدارة حالة الثيم
    function updateThemeIcons() {
        const isDark = document.documentElement.getAttribute('data-bs-theme') === 'dark';
        document.querySelectorAll('#moonIconMobile').forEach(icon => {
            icon.style.display = isDark ? 'none' : 'block';
        });
        document.querySelectorAll('#sunIconMobile').forEach(icon => {
            icon.style.display = isDark ? 'block' : 'none';
        });
    }

    updateThemeIcons();
});
/*-------------------------------------------------------------*/
// Add smooth transition between slides
document.addEventListener('DOMContentLoaded', function () {
    var carousel = document.querySelector('#eliteHavenCarousel');
    if (carousel) {
        carousel.addEventListener('slide.bs.carousel', function () {
            var activeItem = this.querySelector('.carousel-item.active');
            activeItem.style.transition = 'opacity 0.6s ease';
            activeItem.style.opacity = '0';

            setTimeout(() => {
                activeItem.style.opacity = '1';
            }, 50);
        });
    }
});