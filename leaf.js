  let pos = new Vec(size.x / 2, 150);

  let vel = Vec.polar(12, 0);
  let upwards = new Vec(0, -1);
  let rotation = new Vec(1, 0);

  let constants = {
    GRAV: 0.5,
    DRAG: 0.994,
    DRAG_MIN: 10,
    CONTROLS: 0.014,
    ROTATION: 0.002,
  };

  let floor = size.y - 6;

  app.ticker.add(dT => {
    let landed = pos.y >= floor;

    if (landed) {
      pos = new Vec(pos.x, floor);
      upwards = new Vec(0, 1);
      rotation = new Vec(Math.sign(rotation.x), 0);
    } else if (!input.isDown(input.SPACE)) {
      pos = Vec.add(pos, vel);
      pos = Vec.add(pos, new Vec(0, 0.5));

      let delta = Vec.delta(vel, upwards) / (Math.PI / 2);
      delta *= vel.len * constants.ROTATION;

      if (input.isDown(input.LEFT))
        delta -= constants.CONTROLS;
      else if (input.isDown(input.RIGHT))
        delta += constants.CONTROLS;

      vel = Vec.polar(vel.len, vel.dir + delta);
      upwards = Vec.polar(1, upwards.dir + delta);
      rotation = Vec.polar(1, rotation.dir + delta);

      if (vel.y < 0) {
        let grav = Vec.polar(-constants.GRAV, vel.dir);
        vel = Vec.add(vel, grav);
      } else {
        let grav = Vec.polar(constants.GRAV, vel.dir);
        vel = Vec.add(vel, grav);
      }

      if (vel.len < 1) {
        if (upwards.y > 0)
          upwards = Vec.polar(-upwards.len, upwards.dir);
      }

      if (vel.len > constants.DRAG_MIN)
        vel = Vec.polar(vel.len * constants.DRAG, vel.dir);
    }

    let fast = vel.len > 15;
    basic.visible = !fast;
    stretch.visible = fast;

    leaf.x = pos.x;
    leaf.y = pos.y;
    leaf.rotation = rotation.dir;

    console.log(pos.y, size.y);
  });