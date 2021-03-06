export class Vec {
    constructor(
        readonly x: number,
        readonly y: number,
    ) { }

    get len() {
        return Math.sqrt(this.x * this.x + this.y * this.y);
    }

    get dir() {
        return Math.atan2(this.y, this.x);
    }

    static norm(a: Vec) {
        return Vec.polar(1, a.dir);
    }

    static add(a: Vec, b: Vec) {
        return new Vec(a.x + b.x, a.y + b.y);
    }

    static delta(a: Vec, b: Vec) {
        let dot = a.x * b.x + a.y * b.y;
        let abs = Math.acos(dot / a.len / b.len);
        if (a.y * b.x > a.x * b.y)
            return -abs;
        return abs;
    }

    static polar(len: number, dir: number) {
        return new Vec(
            Math.cos(dir) * len,
            Math.sin(dir) * len
        );
    }
}
