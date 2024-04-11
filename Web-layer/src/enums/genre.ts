export enum Genre {
    Genre1,
    Genre2
}

export function getGenreOptions() {
    return Object.keys(Genre).filter(key => isNaN(Number(key)));
}

export function genreStringToValue(genre: string): string {
    switch (genre) {
        case "Genre1":
            return '0';
        case "Genre2":
            return '1';
        default:
            return "undefined"
    }
}
export function genreValueToString(value: number): string {
    switch (value) {
        case 0:
            return "Genre1";
        case 1:
            return "Genre2"
        default:
            return "undefined"
    }
}

