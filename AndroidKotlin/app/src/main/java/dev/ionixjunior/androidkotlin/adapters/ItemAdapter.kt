package dev.ionixjunior.androidkotlin.adapters

import android.view.LayoutInflater
import android.view.ViewGroup
import androidx.recyclerview.widget.RecyclerView
import com.google.android.gms.ads.nativead.NativeAd
import dev.ionixjunior.androidkotlin.R
import dev.ionixjunior.androidkotlin.models.Ad
import dev.ionixjunior.androidkotlin.viewholders.AdViewHolder
import dev.ionixjunior.androidkotlin.viewholders.BaseViewHolder
import dev.ionixjunior.androidkotlin.viewholders.ItemViewHolder

class ItemAdapter(private val itens: MutableList<Any>) : RecyclerView.Adapter<BaseViewHolder>() {
    enum class ItemType {
        Item,
        Ad
    }

    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): BaseViewHolder {
        if (viewType == ItemType.Ad.ordinal) {
            val view = LayoutInflater.from(parent.context).inflate(R.layout.layout_ad, parent, false)
            return AdViewHolder(view)
        }

        val view = LayoutInflater.from(parent.context).inflate(R.layout.layout_item, parent, false)
        return ItemViewHolder(view)
    }

    override fun getItemViewType(position: Int): Int {
        return when (itens[position]) {
            is Ad -> ItemType.Ad.ordinal
            else -> ItemType.Item.ordinal
        }
    }

    override fun getItemCount(): Int {
        return itens.size
    }

    override fun onBindViewHolder(holder: BaseViewHolder, position: Int) {
        val item = itens[position]
        holder.bind(item)
    }

    private val adDefaultDistance = 5;
    private var adNextPosition = adDefaultDistance;

    fun setAd(ad: NativeAd) {
        val adItem = Ad(ad.icon.drawable, ad.headline, ad.body)
        
        if (adNextPosition > itens.size) {
            adNextPosition = itens.size
        }

        itens.add(adNextPosition, adItem)
        notifyItemInserted(adNextPosition)
        adNextPosition += adDefaultDistance + 1
    }
}