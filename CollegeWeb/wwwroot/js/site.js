document.addEventListener("DOMContentLoaded", function () {
    /* ----------HamBurger-----------*/
    document.addEventListener("DOMContentLoaded", function () {
        const hamburger = document.getElementById("hamburger");
        const navLinks = document.getElementById("navLinks");

        if (hamburger && navLinks) {
            hamburger.addEventListener("click", function () {
                navLinks.classList.toggle("active");
            });
        }
    });



    // ======= NEWS SCROLLING =======
    const newsList = document.querySelector(".news-list");
    const newsItems = document.querySelectorAll(".news-list a");

    if (!newsList || newsItems.length === 0) {
        console.error("News list or items not found!");
        return;
    }

    let newsIndex = 0;
    const newsHeight = newsItems[0].clientHeight;

    function scrollNews() {
        newsIndex++;
        if (newsIndex >= newsItems.length) {
            newsIndex = 0;
            newsList.style.transition = "none"; // Remove animation for smooth reset
            newsList.style.transform = `translateY(0)`;
        } else {
            newsList.style.transition = "transform 0.5s ease-in-out";
            newsList.style.transform = `translateY(-${newsHeight * newsIndex}px)`;
        }
    }

    setInterval(scrollNews, 2000); // Scroll every 2 seconds

    // ======= EVENTS CAROUSEL =======
    // ======= EVENTS CAROUSEL (Using translateX) =======
    const slides = document.querySelectorAll('.event-slide');
    const slider = document.querySelector('.events-slider');
    const nextBtn = document.querySelector('.next-btn');
    const prevBtn = document.querySelector('.prev-btn');

    let currentIndex = 0;
    let totalSlides = slides.length;

    function updateSlidePosition() {
        const slideWidth = slides[0].clientWidth;
        slider.style.transform = `translateX(-${currentIndex * slideWidth}px)`;
    }

    function nextSlide() {
        currentIndex = (currentIndex + 1) % totalSlides;
        updateSlidePosition();
    }

    function prevSlide() {
        currentIndex = (currentIndex - 1 + totalSlides) % totalSlides;
        updateSlidePosition();
    }

    nextBtn.addEventListener('click', () => {
        nextSlide();
        resetInterval();
    });

    prevBtn.addEventListener('click', () => {
        prevSlide();
        resetInterval();
    });

    // Auto slide every 3 seconds
    let slideInterval = setInterval(nextSlide, 3000);

    function resetInterval() {
        clearInterval(slideInterval);
        slideInterval = setInterval(nextSlide, 3000);
    }

    // Recalculate slide position on resize
    window.addEventListener('resize', updateSlidePosition);

    // Initial setup
    updateSlidePosition();



    // === Event SLIDES control ===
    const eventSlides = document.querySelectorAll('.event2-slide');
    const eventSlider = document.querySelector('.event2-slider');
    let currentEventIndex = 0;

    function showEvent(index) {
        eventSlider.style.transform = `translateX(-${index * 100}%)`;
        resetPhotoSlider();
    }

    document.querySelector('.event2-prev').addEventListener('click', () => {
        currentEventIndex = (currentEventIndex - 1 + eventSlides.length) % eventSlides.length;
        showEvent(currentEventIndex);
    });

    document.querySelector('.event2-next').addEventListener('click', () => {
        currentEventIndex = (currentEventIndex + 1) % eventSlides.length;
        showEvent(currentEventIndex);
    });

    // === Inner photo slider (sub-slider for each event) ===
    let photoIntervals = [];

    function startPhotoSliderForAllEvents() {
        eventSlides.forEach((slide, slideIndex) => {
            const photos = slide.querySelectorAll('.event-photo');
            let currentPhoto = 0;

            const interval = setInterval(() => {
                photos.forEach(p => p.classList.remove('active'));
                currentPhoto = (currentPhoto + 1) % photos.length;
                photos[currentPhoto].classList.add('active');
            }, 3000);

            photoIntervals.push(interval);
        });
    }

    function resetPhotoSlider() {
        photoIntervals.forEach(clearInterval);
        photoIntervals = [];
        startPhotoSliderForAllEvents();
    }

    // Initial setup
    showEvent(currentEventIndex);
    startPhotoSliderForAllEvents();



    /*-------------------Contact US------------------------*/
    document.addEventListener("DOMContentLoaded", function () {
        const form = document.getElementById("contactForm");
        const statusMessage = document.getElementById("statusMessage");

        form.addEventListener("submit", function (e) {
            e.preventDefault();

            const name = document.getElementById("name").value.trim();
            const email = document.getElementById("email").value.trim();
            const subject = document.getElementById("subject").value.trim();
            const message = document.getElementById("message").value.trim();

            if (!name || !email || !subject || !message) {
                statusMessage.textContent = "Please fill out all fields.";
                statusMessage.classList.remove("hidden");
                statusMessage.classList.add("bg-red-100", "text-red-700");
                return;
            }

            fetch('/Home/SubmitContact', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify({ name, email, subject, message })
            })
                .then(response => {
                    if (response.ok) return response.text();
                    throw new Error("Submission failed.");
                })
                .then(data => {
                    statusMessage.textContent = data;
                    statusMessage.classList.remove("hidden", "bg-red-100", "text-red-700");
                    statusMessage.classList.add("bg-green-100", "text-green-700");
                    form.reset();

                    setTimeout(() => statusMessage.classList.add("hidden"), 3000);
                })
                .catch(error => {
                    statusMessage.textContent = "Something went wrong.";
                    statusMessage.classList.remove("hidden", "bg-green-100", "text-green-700");
                    statusMessage.classList.add("bg-red-100", "text-red-700");
                });
        });
    });


   
});
   


