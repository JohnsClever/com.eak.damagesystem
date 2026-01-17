using System.Collections.Generic;
using UnityEngine;
namespace com.eak.damagesystem
{
    public class HitData
    {
        public float damage;
    }
    public class HitDataDirection : HitData
    {
        public Vector3 hitDirection;
        public Vector3 hitPoint;
    }
    public class HitDataKnockBack : HitDataDirection
    {
        public float knockbackForce;
    }
    public abstract class HitDataBuilder<TBuilder> where TBuilder : HitDataBuilder<TBuilder>
    {
        public float damage;
        public Vector3 hitDirection;
        public Vector3 hitPoint;
        public HitDataBuilder()
        {
        }
        public HitDataBuilder(HitData hitData)
        {
            this.damage = hitData.damage;
        }
        public TBuilder SetDamage(float damage)
        {
            this.damage = damage;
            return (TBuilder)this;
        }

        public TBuilder SetHitDirection(Vector3 direction)
        {
            this.hitDirection = direction;
            return (TBuilder)this;
        }

        public TBuilder SetHitPoint(Vector3 point)
        {
            this.hitPoint = point;
            return (TBuilder)this;
        }

        public abstract HitData Build();
    }
    public class HitDataDirectionBuilder : HitDataBuilder<HitDataDirectionBuilder>
    {
        public HitDataDirectionBuilder() : base()
        {
        }
        public HitDataDirectionBuilder(HitDataDirection hitData) : base(hitData)
        {
            this.hitDirection = hitData.hitDirection;
            this.hitPoint = hitData.hitPoint;
        }
        public override HitData Build()
        {
            return new HitDataDirection()
            {
                damage = this.damage,
                hitDirection = this.hitDirection,
                hitPoint = this.hitPoint
            };
        }
    }
    public class HitDataKnockBackBuilder : HitDataBuilder<HitDataKnockBackBuilder>
    {
        public float knockbackForce;
        public HitDataKnockBackBuilder() : base()
        {
        }
        public HitDataKnockBackBuilder(HitDataKnockBack hitData) : base(hitData)
        {
            this.hitDirection = hitData.hitDirection;
            this.hitPoint = hitData.hitPoint;
            this.knockbackForce = hitData.knockbackForce;
        }
        public HitDataKnockBackBuilder SetKnockbackForce(float force)
        {
            this.knockbackForce = force;
            return this;
        }
        public override HitData Build()
        {
            return new HitDataKnockBack()
            {
                damage = this.damage,
                hitDirection = this.hitDirection,
                hitPoint = this.hitPoint,
                knockbackForce = this.knockbackForce
            };
        }
    }
}