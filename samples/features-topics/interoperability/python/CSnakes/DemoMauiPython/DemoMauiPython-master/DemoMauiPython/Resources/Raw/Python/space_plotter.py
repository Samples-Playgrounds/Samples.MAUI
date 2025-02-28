import matplotlib.pyplot as plt
from astropy.time import Time
from sunpy.coordinates import get_body_heliographic_stonyhurst

from io import BytesIO
from collections.abc import Buffer

face_color = '#FFFFFF'
text_color = '#000000'  # Default text color


def set_theme(background_color: str, axis_text_color: str) -> None:
    global face_color, text_color
    face_color = background_color
    text_color = axis_text_color


def plot_earth_and_planet(planet: str) -> Buffer:
    obstime = Time.now()
    planet_list = ['earth', planet, 'sun']
    planet_coord = [get_body_heliographic_stonyhurst(
        this_planet, time=obstime) for this_planet in planet_list]

    fig = plt.figure(figsize=(5, 5), facecolor=face_color)
    ax = fig.add_subplot(projection='polar')
    ax.set_facecolor(face_color)

    # Set the text color of the axis labels
    ax.tick_params(axis='x', colors=text_color)
    ax.tick_params(axis='y', colors=text_color)
    ax.xaxis.label.set_color(text_color)
    ax.yaxis.label.set_color(text_color)

    for this_planet, this_coord in zip(planet_list, planet_coord):
        ax.plot(this_coord.lon.to('rad'), this_coord.radius, 'o', label=this_planet.capitalize())
    ax.legend()

    plt.show()
    outstream = BytesIO()
    plt.savefig(outstream, format='png', dpi=300)
    return outstream.getbuffer()
