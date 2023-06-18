import { Box, Typography } from "@mui/material";
import Slider from "react-slick";
import { useState, useEffect, useRef } from "react";

export default function HomePage() {
  const settings = {
    infinite: true,
    speed: 250,
    slidesToShow: 1,
    slidesToScroll: 1,
    autoplay: true,
    autoplaySpeed: 3000,
  };

  const [currentSlide, setCurrentSlide] = useState(0);
  const sliderRef = useRef<Slider>(null);

  useEffect(() => {
    const interval = setInterval(() => {
      setCurrentSlide((prevSlide) => (prevSlide + 1) % 3);
      if (sliderRef.current) {
        sliderRef.current.slickNext();
      }
    }, 3000);

    return () => clearInterval(interval);
  }, []);

  return (
    <Box>
      <Slider {...settings} ref={sliderRef}>
        <div>
          <img src="/images/hero1.jpg" alt="slika" style={{ display: 'block', width: '100%', maxHeight: 500 }} />
        </div>
        <div>
          <img src="/images/hero2.jpg" alt="slika" style={{ display: 'block', width: '100%', maxHeight: 500 }} />
        </div>
        <div>
          <img src="/images/hero3.jpg" alt="slika" style={{ display: 'block', width: '100%', maxHeight: 500 }} />
        </div>
      </Slider>
      <Typography style={{ fontFamily: 'Eurostile' }} variant="h2" sx={{ display: 'flex', alignItems: 'flex-start;', ml: 1, mr: 10, mt: 1 }}>
        DOBRODOŠLI U NIIR FAMILIJU
      </Typography>
    </Box>
  );
}
