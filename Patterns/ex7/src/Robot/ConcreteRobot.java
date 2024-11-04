package Robot;

public class ConcreteRobot implements Robot {
    private final String name;
    private int life;
    private int shield;
    private int freq;
    private int canon;

    // Builder
    public ConcreteRobot(Builder builder) {
        this.name = builder.name;
        this.life = builder.life;
        this.shield = builder.shield;
        this.freq = builder.freq;
        this.canon = builder.canon;
    }

    @Override
    public int getCanon() {
        return canon;
    }

    @Override
    public int getShield() {
        return shield;
    }

    @Override
    public int getFreq() {
        return freq;
    }

    @Override
    public String getName() {
        return name;
    }

    @Override
    public int diffLife(int i) {
        life += i;
        return life;
    }


    // comme 2 seules variables sont obligatoires
    // on va utiliser un Builder Pattern
    // ICI CLASSE INTERNE A Robot.ConcreteRobot
    public static class Builder {
        private final String name;
        private int life;
        private int shield;
        private int freq;
        private int canon;

        // Nom toujours obligatoire
        public Builder(String name) {
            this.name = name;
            this.life=100;
            this.shield=1;
            this.freq=1;
            this.canon=1;
        }

        public Builder life(int life) {
            this.life = life;
            return this;
        }

        public Builder shield(int shield) {
            this.shield = shield;
            return this;
        }

        public Builder freq(int freq) {
            this.freq = freq;
            return this;
        }

        public Builder canon(int canon) {
            this.canon = canon;
            return this;
        }

        public ConcreteRobot build() {
            return new ConcreteRobot(this);
        }
    }
}